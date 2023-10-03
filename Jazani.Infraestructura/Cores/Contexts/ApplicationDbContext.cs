using Jazani.Domain.Admins.Models;
using Jazani.Infraestructure.Admins.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Cores.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //private readonly IConfiguration _configuration;

    //public ApplicationDbContext(IConfiguration configuration) { 
    //    _configuration = configuration;
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //    base.OnConfiguring(optionsBuilder);
    //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection"));

    //}

    #region "DbSet"
    public DbSet<Office> Offices { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new OfficeConfiguration());
    }
}
