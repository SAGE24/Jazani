using Jazani.Domain.Soc.Models;
using Jazani.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Soc.Configurations;
public class HolderConfiguration : IEntityTypeConfiguration<Holder>
{
    public void Configure(EntityTypeBuilder<Holder> builder)
    {
        builder.ToTable("holder ", "soc");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Lastname).HasColumnName("lastname");
        builder.Property(t => t.Maidenname).HasColumnName("maidenname");
        builder.Property(t => t.Documentnumber).HasColumnName("documentnumber");
        builder.Property(t => t.Documentnumber2).HasColumnName("documentnumber2");
        builder.Property(t => t.Landline).HasColumnName("landline");
        builder.Property(t => t.Mobile).HasColumnName("mobile");

        builder.Property(t => t.Corporatemail).HasColumnName("corporatemail");        
        builder.Property(t => t.Personalmail).HasColumnName("personalmail");
        
        builder.Property(t => t.Districtid).HasColumnName("districtid");
        builder.Property(t => t.Holderregimeid).HasColumnName("holderregimeid");
        builder.Property(t => t.Holdergroupid).HasColumnName("holdergroupid");
        builder.Property(t => t.Registryofficeid).HasColumnName("registryofficeid");
        builder.Property(t => t.Identificationdocumentid).HasColumnName("identificationdocumentid");
        builder.Property(t => t.Nationalityid).HasColumnName("nationalityid");
        builder.Property(t => t.Civilstatusid).HasColumnName("civilstatusid");
        builder.Property(t => t.Holdertypeid).HasColumnName("holdertypeid");
        builder.Property(t => t.Regimedatestart).HasColumnName("regimedatestart");
        builder.Property(t => t.Regimedateend).HasColumnName("regimedateend");
        builder.Property(t => t.Regimenumberconstancy).HasColumnName("regimenumberconstancy");
        builder.Property(t => t.RegistrationDate)
            .HasColumnName("registrationdate")
            .HasConversion(new DateTimeToDdateTimeOffSet())
            ;
        builder.Property(t => t.State).HasColumnName("state");
        builder.Property(t => t.Holdercategoryid).HasColumnName("holdercategoryid");
        builder.Property(t => t.Isexternal).HasColumnName("isexternal");
        builder.Property(t => t.Ingemmetname).HasColumnName("ingemmetname");
    }
}
