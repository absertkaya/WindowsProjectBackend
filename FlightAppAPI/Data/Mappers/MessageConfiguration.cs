using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Content).IsRequired().HasMaxLength(255);
            builder.Property(m => m.Timestamp).IsRequired();
            builder.HasOne(m => m.Sender).WithMany(p => p.SentMessages).IsRequired();
            builder.HasOne(m => m.Receiver).WithMany(p => p.ReceivedMessages).IsRequired();
        }
    }
}
