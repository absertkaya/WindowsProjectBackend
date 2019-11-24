using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Nr).IsRequired();
            builder.Property(s => s.ClassType).IsRequired();
            builder.HasOne(s => s.Passenger).WithOne(p => p.Seat).HasForeignKey<Passenger>(s => s.SeatId);
            builder.HasOne(s => s.Flight).WithMany(f => f.Seats).IsRequired();
        }
    }
}
