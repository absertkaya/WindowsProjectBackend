using FlightAppAPI.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data
{
    public class DataInitializer
    {

        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<IdentityUser> _um;

        public DataInitializer(ApplicationDbContext ctx, UserManager<IdentityUser> um)
        {
            _ctx = ctx;
            _um = um;
        }

        public async Task InitializeData()
        {
            if (_ctx.Database.EnsureDeleted())
            {
                _ctx.Database.EnsureCreated();
                Product proteinBar = new Product() {ProductName = "Protein Bar", Price = 5, amountInStock = 20, ProductType = ProductType.FOOD };
                _ctx.Products.Add(proteinBar);

                string email = "dude@gmail.com";
                Passenger p1 = new Passenger() { BirthDate = DateTime.Parse("1980/10/10"), Email = email, FirstName = "bob", LastName = "van damme" };
                await CreateUser(email, "Password1*");
                email = "staff@gmail.com";
                Staff staff = new Staff() { Email = email, BirthDate = DateTime.Parse("10/05/1996"), LastName = "Sertkaya", FirstName = "Abdullah" };
                await CreateUser(email, "Password1*");

                _ctx.Passengers.Add(p1);
                _ctx.Staff.Add(staff);

                IList<Seat> seats = new List<Seat>()
            {
                new Seat() {SeatNr = 1, ClassType = ClassType.FIRST, SeatId = 1},
                new Seat() {SeatNr = 1, ClassType = ClassType.ECONOMY, SeatId = 2}
            };

                seats.ToList().ForEach(s => _ctx.Add(s));

                IList<Flight> flights = new List<Flight>()
            {
                new Flight() {
                    FlightId = 1,
                    ArrivalDest = "New York",
                    DepartureDest = "Brussels",
                    ArrivalTime = DateTime.Parse("2019/10/25"),
                    DepartureTime = DateTime.Now
                },
                new Flight() {
                    FlightId = 2,
                    ArrivalDest = "Bangkok",
                    DepartureDest = "Brussels",
                    ArrivalTime = DateTime.Parse("2019/10/27"),
                    DepartureTime = DateTime.Now.AddDays(1)
                },
            };

                flights.ToList().ForEach(f => _ctx.Flights.Add(f));

                IList<Announcement> announcements = new List<Announcement>()
            {
                new Announcement("Discount on food", "there is a 20% discount going on right now"),
                new Announcement("Stop pissing next to the toilet", "Some guy keeps pissing on the floor")
            };

                announcements.ToList().ForEach(a => _ctx.Announcements.Add(a));

                p1.AddFlight(flights[0], seats[0]);
                staff.AddFlight(flights[0]);
                announcements.ToList().ForEach(a => staff.StaffFlights[0].AddAnnouncement(a));
                Plane plane = new Plane() { Seats = seats, Flights = flights };

                _ctx.Planes.Add(plane);

                _ctx.SaveChanges();
            }
            
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _um.CreateAsync(user, password);
        }
    }
}
