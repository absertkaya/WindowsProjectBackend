using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class StaffFlightConfiguration : IEntityTypeConfiguration<StaffFlight>
    {
        public void Configure(EntityTypeBuilder<StaffFlight> builder)
        {
            builder.HasKey(p => new { p.StaffId, p.FlightId });

            builder.HasOne(p => p.Staff).WithMany(s => s.StaffFlights).HasForeignKey(s => s.StaffId);
            builder.HasOne(p => p.Flight).WithMany(f => f.StaffFlights).HasForeignKey(f => f.FlightId);
        }
    }
}