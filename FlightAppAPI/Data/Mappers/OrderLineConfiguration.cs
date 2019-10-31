using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("OrderLines");

            builder.HasKey(l => new { l.OrderId, l.ProductId });
            builder.Property(l => l.Amount).IsRequired();
            builder.HasOne(l => l.Order).WithMany(o => o.OrderLines).IsRequired();
            builder.HasOne(l => l.Product).WithMany();
        }
    }
}
