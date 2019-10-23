using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staff");

            builder.HasMany(p => p.HandledOrders).WithOne().IsRequired(false);
            builder.HasMany(p => p.StaffFlights).WithOne(s => s.Staff).IsRequired();
        }
    }
}
