using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(p => p.ProductName).IsRequired(true).HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired(true);
            builder.Property(p => p.ProductType).IsRequired(true);
            builder.Property(p => p.AmountInStock).IsRequired(true);
        }
    }
}
