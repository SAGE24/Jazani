using Jazani.Domain.Admins.Models;
using Jazani.Domain.Generals.Models;
using Jazani.Infraestructure.Admins.Configurations;
using Jazani.Infraestructure.Generals.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Cores.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    #region "DbSet"
    public DbSet<Office> Offices { get; set; }
    public DbSet<InformationSource> InformationSources { get; set; }
    public DbSet<InformationSourceType> InformationSourceTypes { get; set; }
    public DbSet<MineralType> MineralTypes { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new OfficeConfiguration());
        modelBuilder.ApplyConfiguration(new InformationSourceConfiguration());
        modelBuilder.ApplyConfiguration(new InformationSourceTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MineralTypeConfiguration());
    }
}
