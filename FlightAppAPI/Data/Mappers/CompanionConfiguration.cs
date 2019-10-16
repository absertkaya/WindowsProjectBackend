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
            builder.HasKey(c => new {c.PassengerFlight1Id, c.PassengerFlight2Id });

            builder.HasOne(p => p.PassengerFlight1).WithMany().HasForeignKey(s => s.PassengerFlight1Id);
            builder.HasOne(p => p.PassengerFlight2).WithMany().HasForeignKey(s => s.PassengerFlight2Id);
        }
    }
}
