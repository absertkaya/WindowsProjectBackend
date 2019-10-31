using FlightAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Mappers
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friend");

            builder.HasOne(b => b.Passenger).WithMany(p => p.Friends).IsRequired().HasForeignKey(p => p.PassengerId);
            builder.HasOne(b => b.Passenger2).WithMany().IsRequired().HasForeignKey(p => p.Passenger2Id);
        }
    }
}
