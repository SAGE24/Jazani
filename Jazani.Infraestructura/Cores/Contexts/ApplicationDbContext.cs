using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Jazani.Infraestructure.Cores.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //#region "DbSet"
    //public DbSet<Office> Offices { get; set; }
    //public DbSet<InformationSource> InformationSources { get; set; }
    //public DbSet<InformationSourceType> InformationSourceTypes { get; set; }
    //public DbSet<MineralType> MineralTypes { get; set; }
    //#endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        base.OnModelCreating(modelBuilder);

        //Cambio por ApplyConfigurationsFromAssembly
        //modelBuilder.ApplyConfiguration(new OfficeConfiguration());
        //modelBuilder.ApplyConfiguration(new InformationSourceConfiguration());
        //modelBuilder.ApplyConfiguration(new InformationSourceTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new MineralTypeConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
