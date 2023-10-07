using Jazani.Domain.Generals.Models;
using Jazani.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Generals.Configurations;
public class MeasureunitConfiguration : IEntityTypeConfiguration<Measureunit>
{
    public void Configure(EntityTypeBuilder<Measureunit> builder)
    {
        builder.ToTable("measureunit", "ge");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Measureunitid).HasColumnName("measureunitid");
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Symbol).HasColumnName("symbol");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.Formulaconversion).HasColumnName("formulaconversion");
        builder.Property(t => t.RegistrationDate)
            .HasColumnName("registrationdate")
            .HasConversion(new DateTimeToDdateTimeOffSet())
            ;
        builder.Property(t => t.State).HasColumnName("state");
    }
}
