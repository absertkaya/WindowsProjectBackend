using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("Passengers");
            
            builder.HasMany(p => p.Orders).WithOne(o => o.Customer);
            builder.HasMany(p => p.SentMessages).WithOne(m => m.Sender);
            builder.HasMany(p => p.ReceivedMessages).WithOne(m => m.Receiver);
            builder.HasOne(p => p.Seat).WithOne(s => s.Passenger);
        }
    }
}
