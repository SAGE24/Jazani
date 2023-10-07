using Jazani.Domain.Generals.Models;
using Jazani.Domain.Mc.Models;
using Jazani.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Mc.Configurations;
public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
{
    public void Configure(EntityTypeBuilder<Investment> builder)
    {
        builder.ToTable("investment", "mc");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Amountinvestd).HasColumnName("amountinvestd").HasColumnType("decimal");
        builder.Property(t => t.Year).HasColumnName("year");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.Miningconcessionid).HasColumnName("miningconcessionid");
        builder.Property(t => t.Investmenttypeid).HasColumnName("investmenttypeid");
        builder.Property(t => t.Currencytypeid).HasColumnName("currencytypeid");
        builder.Property(t => t.Periodtypeid).HasColumnName("periodtypeid");
        builder.Property(t => t.Measureunitid).HasColumnName("measureunitid");        
        builder.Property(t => t.RegistrationDate)
            .HasColumnName("registrationdate")
            .HasConversion(new DateTimeToDdateTimeOffSet())
            ;
        builder.Property(t => t.State).HasColumnName("state");
        builder.Property(t => t.Monthname).HasColumnName("monthname");
        builder.Property(t => t.Monthid).HasColumnName("monthid");
        builder.Property(t => t.Accreditationcode).HasColumnName("accreditationcode");
        builder.Property(t => t.Accountantcode).HasColumnName("accountantcode");
        builder.Property(t => t.Holderid).HasColumnName("holderid");
        builder.Property(t => t.Declaredtypeid).HasColumnName("declaredtypeid");
        builder.Property(t => t.Documentid).HasColumnName("documentid");
        builder.Property(t => t.Investmentconceptid).HasColumnName("investmentconceptid");
        builder.Property(t => t.Module).HasColumnName("module");
        builder.Property(t => t.Frecuency).HasColumnName("frecuency");
        builder.Property(t => t.Isdac).HasColumnName("isdac");
        builder.Property(t => t.Metrictons).HasColumnName("metrictons");
        builder.Property(t => t.Declarationdate).HasColumnName("declarationdate");

        builder.HasOne(one => one.Investmentconcept)
            .WithMany(many => many.Investments)
        .HasForeignKey(fk => fk.Investmentconceptid);

        builder.HasOne(one => one.Holder)
            .WithMany(many => many.Investments)
            .HasForeignKey(fk => fk.Holderid);

        builder.HasOne(one => one.Investmenttype)
            .WithMany(many => many.Investments)
            .HasForeignKey(fk => fk.Investmenttypeid);

        builder.HasOne(one => one.Miningconcession)
            .WithMany(many => many.Investments)
            .HasForeignKey(fk => fk.Miningconcessionid);

        builder.HasOne(many => many.Measureunit)
            .WithMany(many => many.Investments)
            .HasForeignKey(fk => fk.Measureunitid);

        builder.HasOne(one => one.Periodtype)
            .WithMany(many => many.Investments)
            .HasForeignKey(fk => fk.Periodtypeid);
    }
}
