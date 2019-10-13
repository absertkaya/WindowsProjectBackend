using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.Property(p => p.DepartureDest).IsRequired(true).HasMaxLength(255);
            builder.Property(p => p.ArrivalDest).IsRequired(true).HasMaxLength(255);
        }
    }
}