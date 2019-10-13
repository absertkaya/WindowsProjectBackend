using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasMany(p => p.Seats).WithOne().IsRequired(true);
            builder.HasMany(p => p.Flights).WithOne().IsRequired(true);
        }
    }
}
