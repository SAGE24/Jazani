﻿using Jazani.Domain.Mc.Models;
using Jazani.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Mc.Configurations;
public class InvestmenttypeConfiguration : IEntityTypeConfiguration<Investmenttype>
{
    public void Configure(EntityTypeBuilder<Investmenttype> builder)
    {
        builder.ToTable("investmenttype", "mc");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.RegistrationDate)
            .HasColumnName("registrationdate")
            .HasConversion(new DateTimeToDdateTimeOffSet())
            ;
        builder.Property(t => t.State).HasColumnName("state");
    }
}
