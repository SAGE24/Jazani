using Jazani.Domain.Generals.Models;
using Jazani.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Generals.Configurations;
public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
{
    public void Configure(EntityTypeBuilder<PersonType> builder)
    {
        builder.ToTable("persontype", "ge");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.RegistrationDate)
            .HasColumnName("registrationdate")
            .HasConversion(new DateTimeToDdateTimeOffSet())
            ;
        builder.Property(t => t.State).HasColumnName("state");
    }
}
