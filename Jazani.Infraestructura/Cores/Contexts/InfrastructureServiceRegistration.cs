using Jazani.Domain.Cores.Paginations;
using Jazani.Infraestructure.Cores.Paginations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Infraestructure.Cores.Contexts;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        });

        //Cambia por autofac
        //services.AddTransient<IOfficeRepository, OfficeRepository>();
        //services.AddTransient<IInformationSourceRepository, InformationSourceRepository>();
        //services.AddTransient<IInformationSourceTypeRepository, InformationSourceTypeRepository>();
        //services.AddTransient<IMineralTypeRepository, MineralTypeRepository>();

        services.AddTransient(typeof(IPaginator<>), typeof(Paginator<>));

        return services;
    }
}
