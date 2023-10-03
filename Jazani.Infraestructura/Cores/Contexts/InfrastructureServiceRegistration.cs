using Jazani.Domain.Admins.Repositories;
using Jazani.Infraestructure.Admins.Persistences;
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

        //Domain
        services.AddTransient<IOfficeRepository, OfficeRepository>();

        return services;
    }
}
