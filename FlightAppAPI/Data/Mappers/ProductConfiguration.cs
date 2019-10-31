using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Picture).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Type).IsRequired();
        }
    }
}
