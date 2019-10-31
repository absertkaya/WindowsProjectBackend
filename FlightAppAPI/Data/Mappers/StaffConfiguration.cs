using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staff");
            
            builder.HasMany(s => s.SentAnnouncements).WithOne(a => a.Sender);
            builder.HasOne(p => p.Flight).WithMany(f => f.Staff).IsRequired();
        }
    }
}
