﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jazani.Application.Cores.Contexts;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //Cambio por Autofac
        //services.AddTransient<IOfficeService, OfficeService>();
        //services.AddTransient<IInformationSourceService, InformationSourceService>();
        //services.AddTransient<IInformationSourceTypeService, InformationSourceTypeService>();
        //services.AddTransient<IMineralTypeService, MineralTypeService>();


        return services;
    }
}
