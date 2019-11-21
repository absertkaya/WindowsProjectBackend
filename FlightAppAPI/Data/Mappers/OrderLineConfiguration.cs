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

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Amount).IsRequired();
            builder.HasOne(l => l.Product);
        }
    }
}
