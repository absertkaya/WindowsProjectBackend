using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Timestamp).IsRequired();
            builder.Property(o => o.OrderStatus).IsRequired();
            builder.HasOne(o => o.Customer).WithMany(p => p.Orders).IsRequired();
            builder.HasMany(o => o.OrderLines).WithOne().IsRequired();
        }
    }
}
