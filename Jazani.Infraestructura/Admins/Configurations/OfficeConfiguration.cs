using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Admins.Configurations;
public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.ToTable("office", "adm");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
        builder.Property(t => t.State).HasColumnName("state");

    }
}
