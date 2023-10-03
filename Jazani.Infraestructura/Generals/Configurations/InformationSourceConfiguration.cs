using Jazani.Domain.Generals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Generals.Configurations;
public class InformationSourceConfiguration : IEntityTypeConfiguration<InformationSource>
{
    public void Configure(EntityTypeBuilder<InformationSource> builder)
    {
        builder.ToTable("informationsource", "ge");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.InformationSourceid).HasColumnName("informationsourceid");
        builder.Property(t => t.InformationSourceTypeId).HasColumnName("informationsourcetypeid");
        builder.Property(t => t.Initials).HasColumnName("initials");
        builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
        builder.Property(t => t.State).HasColumnName("state");
    }
}
