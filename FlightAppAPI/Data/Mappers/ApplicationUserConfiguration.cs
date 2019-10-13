using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.LastName).IsRequired(true).HasMaxLength(255);
            builder.Property(p => p.FirstName).IsRequired(true).HasMaxLength(255);
            builder.Property(p => p.BirthDate).IsRequired(true);
        }
    }
}