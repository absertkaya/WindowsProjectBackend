using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class CompanionConfiguration : IEntityTypeConfiguration<Companion>
    {
        public void Configure(EntityTypeBuilder<Companion> builder)
        {
            builder.ToTable("Companion");
            builder.HasKey(c => new {c.FlightId1, c.FlightId2 });

            builder.HasOne(p => p.Flight1).WithMany().HasForeignKey(s => s.FlightId1);
            builder.HasOne(p => p.Flight2).WithMany().HasForeignKey(s => s.FlightId2);
        }
    }
}
