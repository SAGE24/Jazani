using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Jazani.Api.Filters;
using Jazani.Api.Middlewares;
using Jazani.Application.Cores.Contexts;
using Jazani.Infraestructure.Cores.Contexts;
using Serilog;
using Serilog.Events;

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
