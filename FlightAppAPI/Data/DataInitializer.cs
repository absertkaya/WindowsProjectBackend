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
                List<Product> products = new List<Product> {
                    new Product { Name = "BOSS - Orange Women", Description = "Eau de toilette 50ml", Price = 30, Type = ProductType.COSMETICS, Picture = "https://fimgs.net/mdimg/perfume/375x500.5979.jpg" },
                    new Product { Name = "Donna Karan - DKNY Women", Description = "Eau de parfum 50ml", Price = 30, Type = ProductType.COSMETICS, Picture = "https://fimgs.net/mdimg/perfume/375x500.504.jpg" },
                    new Product { Name = "Tommy Hilfiger - Tommy Boy", Description = "Eau de cologne 100ml", Price = 30, Type = ProductType.COSMETICS, Picture = "https://cdn.shopify.com/s/files/1/2718/8506/products/tommy_boy.jpg?v=1524957073" },
                    new Product { Name = "Tommy Hilfiger - Tommy Girl", Description = "Eau de cologne 100ml", Price = 30, Type = ProductType.COSMETICS, Picture = "https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&ved=2ahUKEwiNgP7qtMblAhWNY1AKHUIUC-oQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.amazon.com%2FTommy-Hilfiger-Toilette-Spray-Women%2Fdp%2FB00QMSAYYG&psig=AOvVaw1MM_6uWn7A-b-seUeLZt1l&ust=1572608363291070" },
                    new Product { Name = "Amare", Description = "Tomorrowland", Price = 25, Type = ProductType.COLLECTORS, Picture = "http://www.socatec.aero/I-Grande-10541-maquette-a320-tomorrowland-brussels-airlines-plastique-1-200e.net.jpg" },
                    new Product { Name = "Magrite", Description = "René Magritte", Price = 25, Type = ProductType.COLLECTORS, Picture = "http://en.socatec.aero/I-Moyenne-9710-a320-magritte-brussels-airlines-oo-snc-plastic-1-200th.net.jpg" },
                    new Product { Name = "Trident", Description = "Belgian Red Devils", Price = 25, Type = ProductType.COLLECTORS, Picture = "http://en.socatec.aero/I-Moyenne-9571-airbus-a320-trident-red-devils-themed-brussels-airlines-aeroplane.net.jpg" },
                    new Product { Name = "Feta Sandwich", Description = "Grilled bell peppers, feta, and arugula", Price = 6, Type = ProductType.FOOD, Picture = "https://assets.bonappetit.com/photos/57b08765f1c801a1038bd8be/16:9/w_1000,c_limit/hummus-and-feta-sandwiches-on-whole-grain-bread-646.jpg" },
                    new Product { Name = "Chicken Tandoori Wrap", Description = "Roasted chicken breast and chopped carrots topped with a tandoori yogurt dressing", Price = 6, Type = ProductType.FOOD, Picture = "https://recipes.lidl.co.uk/var/lidl-recipes/storage/images/united-kingdom/recipes/tandoori-chicken-wraps/1196397-2-eng-GB/Tandoori-chicken-wraps.jpg" },
                    new Product { Name = "Duo Sandwich", Description = "Try a real Belgian sandwich with cheese and ovenbaked ham.", Price = 6, Type = ProductType.FOOD, Picture = "https://www.hardens.com/wp-content/uploads/2019/08/Mortadella-taleggio-smoked-Isle-of-Wight-tomato-rocket-Thai-basil-cider-vinaigrette-on-focaccia-1-940x1024.jpeg" },
                    new Product { Name = "Twix", Price = 2.5M, Type = ProductType.SNACKS, Picture = "https://cdn.influenster.com/media/product/image/Twix-psd88929.png.750x750_q85ss0_progressive.png" },
                    new Product { Name = "M&M's", Price = 2.5M, Type = ProductType.SNACKS, Picture = "https://www.instabasket.eu/4226-tm_large_default/MnM-Crispy.jpg" },
                    new Product { Name = "LEO Waffle", Price = 2, Type = ProductType.SNACKS, Picture = "https://images-na.ssl-images-amazon.com/images/I/71qpfLUKHdL._SY355_.jpg" },
                    new Product { Name = "Coca Cola", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.myamericanmarket.com/873-large_default/coca-cola-classic.jpg" },
                    new Product { Name = "Lipton Ice Tea", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.makro.co.za/sys-master/images/h7c/h0d/9270364700702/silo-MIN_50002762002_CSA_large" },
                    new Product { Name = "Minute Maid Orange", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.dollargeneral.com/media/catalog/product/cache/image/beff4985b56e3afdbeabfc89641a4582/0/0/00025000056031_a1a3_900_900.jpg" },
                    new Product { Name = "Coffee", Price = 3.5M, Type = ProductType.DRINKS, Picture = "https://images.theconversation.com/files/126820/original/image-20160615-14016-njqw65.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=926&fit=clip" },
                };
                products.ForEach(p => _ctx.Products.Add(p));

                Flight flight = new Flight { DepartureTime = DateTime.Now.AddHours(-1), ArrivalTime = DateTime.Now.AddHours(14.5), DepartureDest = "London - Heathrow Airport", ArrivalDest = "Tokyo - Narita Airport" };
                List<Seat> seats = new List<Seat>();
                for (int i = 1; i <= 10; i++)
                {
                    seats.Add(new Seat { ClassType = ClassType.FIRST, Nr = i, Flight = flight });
                }
                for (int i = 11; i <= 40; i++)
                {
                    seats.Add(new Seat { ClassType = ClassType.ECONOMY, Nr = i, Flight = flight });
                }
                flight.Seats = seats;
                List<Passenger> passengers = new List<Passenger>
                {
                    new Passenger { LastName = "Doe", FirstName = "John", BirthDate = DateTime.Parse("1980/10/10"), Email = "p1@gmail.com", Seat = seats[0] },
                    new Passenger { LastName = "Smith", FirstName = "James", BirthDate = DateTime.Parse("1980/10/10"), Email = "p2@gmail.com", Seat = seats[1] },
                    new Passenger { LastName = "Johnson", FirstName = "Robert", BirthDate = DateTime.Parse("1980/10/10"), Email = "p3@gmail.com", Seat = seats[2] },
                    new Passenger { LastName = "Williams", FirstName = "Mary", BirthDate = DateTime.Parse("1980/10/10"), Email = "p4@gmail.com", Seat = seats[10] },
                    new Passenger { LastName = "Jones", FirstName = "Jennifer", BirthDate = DateTime.Parse("1980/10/10"), Email = "p5@gmail.com", Seat = seats[11] },
                    new Passenger { LastName = "Brown", FirstName = "David", BirthDate = DateTime.Parse("1980/10/10"), Email = "p6@gmail.com", Seat = seats[12] },
                    new Passenger { LastName = "Davis", FirstName = "Richard", BirthDate = DateTime.Parse("1980/10/10"), Email = "p7@gmail.com", Seat = seats[13] },
                    new Passenger { LastName = "Miller", FirstName = "Susan", BirthDate = DateTime.Parse("1980/10/10"), Email = "p8@gmail.com", Seat = seats[14] },
                    new Passenger { LastName = "Wilson", FirstName = "Elizabeth", BirthDate = DateTime.Parse("1980/10/10"), Email = "p9@gmail.com", Seat = seats[15] },
                };
                seats[0].Passenger = passengers[0];
                seats[1].Passenger = passengers[1];
                seats[2].Passenger = passengers[2];
                seats[10].Passenger = passengers[3];
                seats[11].Passenger = passengers[4];
                seats[12].Passenger = passengers[5];
                seats[13].Passenger = passengers[6];
                seats[14].Passenger = passengers[7];
                seats[15].Passenger = passengers[8];
                passengers[0].Friends.Add(passengers[1]);
                await CreateUser("p1@gmail.com", "Password1*");
                await CreateUser("p2@gmail.com", "Password1*");
                await CreateUser("p3@gmail.com", "Password1*");
                await CreateUser("staff@gmail.com", "Password1*");
                Staff staff = new Staff { LastName = "Lee", FirstName = "Stan", BirthDate = DateTime.Parse("1980/10/10"), Email = "staff@gmail.com", Flight = flight };
                flight.Announcements.Add(new Announcement { Sender = staff, Title = "Flight info", Content = "1 Hour has passed, 14.5 hours to go" });
                flight.Announcements.Add(new Announcement { Sender = staff, Title = "Turbulence", Content = "We will be experiencing turbulence for the next 15 minutes. Please tighten seatbelt" });
                flight.Staff.Add(staff);
                _ctx.Flights.Add(flight);

                /*
                Product proteinBar = new Product() {ProductName = "Protein Bar", Price = 5, AmountInStock = 20, ProductType = ProductType.FOOD };
                _ctx.Products.Add(proteinBar);

                string email = "client@gmail.com";
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
                    new Announcement() { Title = "Discount on food", Content = "there is a 20% discount going on right now" },
                    new Announcement() { Title = "Stop pissing next to the toilet", Content = "Some guy keeps pissing on the floor" }
                };

                announcements.ToList().ForEach(a => _ctx.Announcements.Add(a));

                p1.AddFlight(flights[0], seats[0]);
                staff.AddFlight(flights[0]);
                announcements.ToList().ForEach(a => staff.StaffFlights[0].AddAnnouncement(a));
                Plane plane = new Plane() { Seats = seats, Flights = flights };

                _ctx.Planes.Add(plane);
                */
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
