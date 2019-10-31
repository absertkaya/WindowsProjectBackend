using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightAppAPI.Data.Mappers
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(40);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(40);
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Type).IsRequired();
        }
    }
}