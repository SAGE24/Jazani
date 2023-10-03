using Jazani.Domain.Generals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Generals.Configurations;
public class InformationSourceTypeConfiguration : IEntityTypeConfiguration<InformationSourceType>
{
    public void Configure(EntityTypeBuilder<InformationSourceType> builder)
    {
        builder.ToTable("informationsourcetype", "ge");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
        builder.Property(t => t.State).HasColumnName("state");
    }
}
