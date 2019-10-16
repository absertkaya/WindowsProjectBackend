using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");

            builder.Property(m => m.Content).IsRequired().HasMaxLength(1023);

            builder.HasOne(m => m.Sender).WithMany(p => p.SentMessages).IsRequired().HasForeignKey(m => m.SenderId);
            builder.HasOne(m => m.Receiver).WithMany(p => p.ReceivedMessages).IsRequired().HasForeignKey(m => m.ReceiverId);
        }
    }
}
