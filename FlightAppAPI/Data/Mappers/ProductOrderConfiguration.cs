using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasKey(p => new { p.OrderId, p.ProductId });

            builder.HasOne(p => p.Order).WithMany(o => o.ProductOrders).HasForeignKey(s => s.OrderId);
            builder.HasOne(p => p.Product).WithMany().HasForeignKey(f => f.ProductId);
        }
    }
}
