using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Jazani.Api.Filters;
using Jazani.Api.Middlewares;
using Jazani.Application.Cores.Contexts;
using Jazani.Core.Securities.Services;
using Jazani.Core.Securities.Services.Implementations;
using Jazani.Infraestructure.Cores.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(".." + Path.DirectorySeparatorChar + "loggApi.log", LogEventLevel.Warning, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.

//Agregar filtro
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());

    AuthorizationPolicy authorizationPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    options.Filters.Add(new AuthorizeFilter());
});


builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

//Route Options
builder.Services.Configure<RouteOptions>(options => { 
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//PasswordHasher
builder.Services.Configure<PasswordHasherOptions>(options => {
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

//ISecurityService
builder.Services.AddTransient<ISecurityService, SecurityService>();

//Jwt
string jwtSecurityKey = builder.Configuration.GetSection("Security:JwtSecrectKey").Get<string>();
builder.Services.AddAuthentication(options => { 
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    byte[] key = Encoding.ASCII.GetBytes(jwtSecurityKey);
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidIssuer = "",
        ValidAudience = "",
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true
    };
});

//AuthorizeOperationFilter
builder.Services.AddSwaggerGen(options => {
    options.OperationFilter<AuthorizeOperationFilter>();

    string schemeName = "Bearer";
    options.AddSecurityDefinition(schemeName, new OpenApiSecurityScheme() { 
        Name = schemeName,
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Add Token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http
    });
});

//Infraestructe
builder.Services.AddInfrastructureServices(builder.Configuration);

//Application
builder.Services.AddApplicationServices();

//AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options => {
        options.RegisterModule(new InfrastructureAutoFacModule());
        options.RegisterModule(new ApplicationAutoFacModule());
        //options.RegisterModule(new ExceptionMiddleware());
    });

builder.Services.AddTransient<ExceptionMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
