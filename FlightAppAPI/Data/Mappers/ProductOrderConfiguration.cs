using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("ProductOrder");

            builder.HasKey(p => new { p.OrderId, p.ProductId });

            builder.HasOne(p => p.Order).WithMany(o => o.OrderLines).HasForeignKey(s => s.OrderId);
            builder.HasOne(p => p.Product).WithMany().HasForeignKey(f => f.ProductId);
        }
    }
}
