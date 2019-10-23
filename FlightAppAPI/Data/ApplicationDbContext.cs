using FlightAppAPI.Data.Mappers;
using FlightAppAPI.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanionConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerFlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOrderConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new StaffFlightConfiguration());
        }
    }
}
