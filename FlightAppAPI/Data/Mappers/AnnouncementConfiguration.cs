using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcements");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Timestamp).IsRequired();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Content).IsRequired().HasMaxLength(255);
            builder.HasOne(a => a.Sender).WithMany(s => s.SentAnnouncements).IsRequired();
        }
    }
}
