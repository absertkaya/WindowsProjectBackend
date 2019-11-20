﻿using FlightAppAPI.Domain;
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
                    new Product { Name = "Feta Sandwich", Description = "Grilled bell peppers, feta, and arugula", Price = 6, Type = ProductType.FOOD, Picture = "https://assets.bonappetit.com/photos/57b08765f1c801a1038bd8be/16:9/w_1000,c_limit/hummus-and-feta-sandwiches-on-whole-grain-bread-646.jpg" },
                    new Product { Name = "Chicken Tandoori Wrap", Description = "Roasted chicken breast and chopped carrots topped with a tandoori yogurt dressing", Price = 6, Type = ProductType.FOOD, Picture = "https://recipes.lidl.co.uk/var/lidl-recipes/storage/images/united-kingdom/recipes/tandoori-chicken-wraps/1196397-2-eng-GB/Tandoori-chicken-wraps.jpg" },
                    new Product { Name = "Duo Sandwich", Description = "Try a real Belgian sandwich with cheese and ovenbaked ham.", Price = 6, Type = ProductType.FOOD, Picture = "https://www.hardens.com/wp-content/uploads/2019/08/Mortadella-taleggio-smoked-Isle-of-Wight-tomato-rocket-Thai-basil-cider-vinaigrette-on-focaccia-1-940x1024.jpeg" },
                    new Product { Name = "Pizza Pepperoni", Description = "A handcrafted and oven baked traditional Italian pizza, topped with spicy salami and mozzarella cheese.", Price = 6, Type = ProductType.FOOD, Picture = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fcdn-image.myrecipes.com%2Fsites%2Fdefault%2Ffiles%2Fstyles%2Fmedium_2x%2Fpublic%2Fimage%2Frecipes%2Fck%2Fgluten-free-cookbook%2Fpepperoni-pizza-ck-x.jpg%3Fitok%3DNWreajsZ&w=450&c=sc&poi=face&q=85" },
                    new Product { Name = "Ham and cheese toast", Description = "Ham and Emmental cheese layered between sliced bread, toasted with a Pecorino cheese crust. Tastes delicious!", Price = 6, Type = ProductType.FOOD, Picture = "https://www.simplyrecipes.com/wp-content/uploads/2013/04/green-eggs-ham-sandwich-horiz-a-1800.jpg" },
                    new Product { Name = "Belgian French Fries", Description = "Warm oven-baked golden fries. A Belgian favourite enjoyed best with mayonnaise or ketchup dipping sauce.", Price = 4, Type = ProductType.FOOD, Picture = "https://www.dw.com/image/17845818_303.jpg" },
                    new Product { Name = "Chicken sweet and sour", Description = "Chicken with crispy vegetables in a typical sweet sweet & sour sauce accompanied with rice.", Price = 7, Type = ProductType.FOOD, Picture = "https://www.daringgourmet.com/wp-content/uploads/2014/02/Sweet-and-Sour-Chicken-6.jpg" },
                    new Product { Name = "Lasagna", Description = "Layers of pasta in a herby tomato sauce with minced meat, topped with béchamel sauce.", Price = 7, Type = ProductType.FOOD, Picture = "https://hips.hearstapps.com/vidthumb/images/180820-bookazine-delish-01280-1536610916.jpg?crop=0.855xw%3A0.721xh%3B0%2C0.275xh&resize=480%3A270" },
                    new Product { Name = "Chicken tikka masala", Description = "The world famous Indian dish: a traditional Tikka Masala sauce accompanied with pilau roce and chicken.", Price = 7, Type = ProductType.FOOD, Picture = "https://img.taste.com.au/38ZvxicR/taste/2016/11/easy-slow-cooker-chicken-tikka-masala-101969-1.jpeg" },
                    new Product { Name = "Twix", Price = 2.5M, Type = ProductType.SNACKS, Picture = "https://cdn.influenster.com/media/product/image/Twix-psd88929.png.750x750_q85ss0_progressive.png" },
                    new Product { Name = "M&M's", Price = 2.5M, Type = ProductType.SNACKS, Picture = "https://www.instabasket.eu/4226-tm_large_default/MnM-Crispy.jpg" },
                    new Product { Name = "LEO Waffle", Price = 2, Type = ProductType.SNACKS, Picture = "https://images-na.ssl-images-amazon.com/images/I/71qpfLUKHdL._SY355_.jpg" },
                    new Product { Name = "Vanilla Muffin", Price = 3, Type = ProductType.SNACKS, Picture = "https://locarbu.com/wp-content/uploads/2013/11/p-2650-greatvanillamuffin.jpg" },
                    new Product { Name = "Pringles Chips", Price = 2.5M, Type = ProductType.SNACKS, Picture = "https://qph.fs.quoracdn.net/main-qimg-86df47f5eda8020fc9b9c59d2f76b038" },
                    new Product { Name = "Tuc", Price = 2.5M, Type = ProductType.SNACKS, Picture = "https://images-na.ssl-images-amazon.com/images/I/81pnhQU0OBL._SX679_.jpg" },
                    new Product { Name = "Nacho dip", Price = 3, Type = ProductType.SNACKS, Picture = "https://cookthestory.com/wp-content/uploads/2018/04/Nacho-Dip-with-toritillas.jpg" },
                    new Product { Name = "Coca Cola", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.myamericanmarket.com/873-large_default/coca-cola-classic.jpg" },
                    new Product { Name = "Lipton Ice Tea", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.makro.co.za/sys-master/images/h7c/h0d/9270364700702/silo-MIN_50002762002_CSA_large" },
                    new Product { Name = "Minute Maid Orange", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.dollargeneral.com/media/catalog/product/cache/image/beff4985b56e3afdbeabfc89641a4582/0/0/00025000056031_a1a3_900_900.jpg" },
                    new Product { Name = "Tomato Soup", Price = 3, Type = ProductType.DRINKS, Picture = "https://i.ytimg.com/vi/X_lZ49spG5A/maxresdefault.jpg" },
                    new Product { Name = "Green Tea", Price = 3, Type = ProductType.DRINKS, Picture = "https://i0.wp.com/images-prod.healthline.com/hlcmsresource/images/AN_images/green-tea-white-mug-1296x728.jpg?w=1155&h=1528" },
                    new Product { Name = "Hot Chocolate", Price = 3, Type = ProductType.DRINKS, Picture = "https://images.food52.com/9zCOvPeJ2V1IgkPGywwkcyr2sDI=/1200x675/9bdf251e-6032-4f20-bc4e-7f944a256c13--2011-1115_perfect-hot-chocolate_james-ransom-6669.jpg" },
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
                passengers[0].AddFriend(passengers[1]);
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
