using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flights");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.DepartureTime).IsRequired();
            builder.Property(f => f.ArrivalTime).IsRequired();
            builder.Property(f => f.DepartureDest).IsRequired().HasMaxLength(200);
            builder.Property(f => f.ArrivalDest).IsRequired().HasMaxLength(200);
            builder.HasMany(f => f.Announcements).WithOne().IsRequired();
        }
    }
}