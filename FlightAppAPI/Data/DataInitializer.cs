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
                    new Product { Name = "Lotus hot waffle", Price = 3, Type = ProductType.SNACKS, Picture = "https://www.belgianchocs.com/catalog/images/luiksewafel.jpg" },
                    new Product { Name = "Lotus chocolate waffle", Price = 3, Type = ProductType.SNACKS, Picture = "https://www.belgianchocs.com/catalog/images/lotusjumbo.jpg" },
                    new Product { Name = "Tuscan Cashews", Price = 3, Type = ProductType.SNACKS, Picture = "https://www.odlicno.eu/sites/default/files/izdelek/tuscan%20cashews%202.jpg" },
                    new Product { Name = "Coca Cola", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.myamericanmarket.com/873-large_default/coca-cola-classic.jpg" },
                    new Product { Name = "Lipton Ice Tea", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.makro.co.za/sys-master/images/h7c/h0d/9270364700702/silo-MIN_50002762002_CSA_large" },
                    new Product { Name = "Minute Maid Orange", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.dollargeneral.com/media/catalog/product/cache/image/beff4985b56e3afdbeabfc89641a4582/0/0/00025000056031_a1a3_900_900.jpg" },
                    new Product { Name = "Fanta Orange", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.coca-cola.co.uk/content/dam/journey/gb/en/hidden/Products/lead-brand-image/Journey-brands-Product-FANTA-Orange-1.rendition.320.179.jpg" },
                    new Product { Name = "Spa Reine", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.yumbel.be/wp-content/uploads/2017/06/Spa_glas.jpg" },
                    new Product { Name = "Green Tea", Price = 3, Type = ProductType.DRINKS, Picture = "https://i0.wp.com/images-prod.healthline.com/hlcmsresource/images/AN_images/green-tea-white-mug-1296x728.jpg?w=1155&h=1528" },
                    new Product { Name = "Black Tea", Price = 3, Type = ProductType.DRINKS, Picture = "https://5.imimg.com/data5/KB/KI/LZ/SELLER-81627793/orthodox-black-tea-500x500.JPG" },
                    new Product { Name = "Mint Tea", Price = 3, Type = ProductType.DRINKS, Picture = "https://www.thespruceeats.com/thmb/-d9q3kCRjxUtsQE9Y_kzvSwqnBA=/2048x1362/filters:fill(auto,1)/easy-fresh-mint-tea-recipe-766391-6_preview-5b291f95ba61770036733329.jpeg" },
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
                List<Message> messages = new List<Message>
                {
                    new Message {Receiver = passengers[0], Sender= passengers[1], Content = "Yo, what's up?", Timestamp = DateTime.Now},
                    new Message {Receiver = passengers[1], Sender= passengers[0], Content = "Not much, just enjoying the scenery. You?", Timestamp = DateTime.Now.AddMinutes(5)},
                    new Message {Receiver = passengers[0], Sender= passengers[1], Content = "Nice", Timestamp = DateTime.Now.AddMinutes(7)},
                    new Message {Receiver = passengers[0], Sender= passengers[1], Content = "Same, it's still such a long way till we get there. I'm kinda bored.", Timestamp = DateTime.Now.AddMinutes(8)},
                };
                passengers[0].SentMessages.Add(messages[0]);
                passengers[0].ReceivedMessages.Add(messages[1]);
                passengers[0].SentMessages.Add(messages[2]);
                passengers[0].SentMessages.Add(messages[3]);
                
                passengers[1].ReceivedMessages.Add(messages[0]);
                passengers[1].SentMessages.Add(messages[1]);
                passengers[1].ReceivedMessages.Add(messages[2]);
                passengers[1].ReceivedMessages.Add(messages[3]);

                Order order = new Order();
                OrderLine line = new OrderLine(products[0], 3);
                OrderLine line2 = new OrderLine(products[1], 5);
                order.OrderLines.Add(line);
                order.OrderLines.Add(line2);

                order.Customer = passengers[0];

                await CreateUser("p1@gmail.com", "Password1*");
                await CreateUser("p2@gmail.com", "Password1*");
                await CreateUser("p3@gmail.com", "Password1*");
                await CreateUser("staff@gmail.com", "Password1*");
                Staff staff = new Staff { LastName = "Lee", FirstName = "Stan", BirthDate = DateTime.Parse("1980/10/10"), Email = "staff@gmail.com", Flight = flight };
                flight.Announcements.Add(new Announcement { Sender = staff, Title = "Flight info", Content = "1 Hour has passed, 14.5 hours to go" });
                flight.Announcements.Add(new Announcement { Sender = staff, Title = "Turbulence", Content = "We will be experiencing turbulence for the next 15 minutes. Please tighten seatbelt" });
                flight.Staff.Add(staff);
                _ctx.Flights.Add(flight);

                // Movies
                List<Movie> movies = new List<Movie> {
                    new Movie("Star Wars: The Rise of Skywalker", DateTime.Parse("19/12/2019"), 141, "The surviving Resistance faces the First Order once more in the final chapter of the Skywalker saga.", "J.J. Abrams", "https://m.media-amazon.com/images/M/MV5BMDljNTQ5ODItZmQwMy00M2ExLTljOTQtZTVjNGE2NTg0NGIxXkEyXkFqcGdeQXVyODkzNTgxMDg@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/8Qn_spdM5Zg"){ Id = 1 },
                    new Movie("The Shawshank Redemption", DateTime.Parse("17/2/1995"), 142, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency. ", "F. Darabont", "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/6hB3S9bIaco"){ Id = 2 },
                    new Movie("The Godfather", DateTime.Parse("24/8/1972"), 175, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son. ", "F. F. Coppola", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR3,0,182,268_AL_.jpg", "https://www.youtube.com/embed/CWoQlDlyQj4"){ Id = 3 },
                    new Movie("The Godfather: Part II", DateTime.Parse("15/5/1975"), 202, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate. ", "F.F. Coppola", "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR3,0,182,268_AL_.jpg", "https://www.youtube.com/embed/9O1Iy9od7-A"){ Id = 4 },
                    new Movie("Schindler's List", DateTime.Parse("18/2/1994"), 195, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "S. Spielberg", "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/gG22XNhtnoY"){ Id = 5 },
                    new Movie("The Lord of the Rings: The Fellowship of the Ring", DateTime.Parse("19/12/2001"), 178, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron. ", "P. Jackson", "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/V75dMMIW2B4"){ Id = 6 },
                    new Movie("The Lord of the Rings: The Two Towers", DateTime.Parse("18/12/2002"), 179, "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", "P. Jackson", "https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/hYcw5ksV8YQ"){ Id = 7 },
                    new Movie("The Lord of the Rings: The Return of the King", DateTime.Parse("17/12/2003"), 201, "TGandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "P. Jackson", "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg", "https://www.youtube.com/embed/r5X-hFf6Bwo"){ Id = 8 },
                    new Movie("Pulp Fiction", DateTime.Parse("21/10/1994"), 154, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption. ", "Q. Tarantino", "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR1,0,182,268_AL_.jpg", "https://www.youtube.com/embed/s7EdQ4FqbhY"){ Id = 9 }
                };
                movies.ForEach(m => _ctx.Movies.Add(m));

                // Music
                List<Music> music = new List<Music> {
                    new Music("God's Plan", "Drake", "https://charts-static.billboard.com/img/2018/01/drake-hq6-87x87.jpg"){ Id = 1 },
                    new Music("Perfect", "Ed Sheeran", "https://charts-static.billboard.com/img/2017/03/ed-sheeran-buv-87x87.jpg"){ Id = 2 },
                    new Music("Meant To Be", "Bebe Rexha", "https://charts-static.billboard.com/img/2017/10/bebe-rexha-8wm-87x87.jpg"){ Id = 3 },
                    new Music("Havana", "Camila Cabello", "https://charts-static.billboard.com/img/2017/08/camila-cabello-4tx-87x87.jpg"){ Id = 4 },
                    new Music("Rockstar", "Post Malone", "https://charts-static.billboard.com/img/2017/10/post-malone-1vw-87x87.jpg"){ Id = 5 },
                    new Music("Psycho", "Post Malone", "https://charts-static.billboard.com/img/2018/03/post-malone-tp6-87x87.jpg"){ Id = 6 },
                    new Music("I Like It", "Cardi B", "https://charts-static.billboard.com/img/2018/04/cardi-b-n38-i-like-it-ppy-87x87.jpg"){ Id = 7 },
                    new Music("The Middle", "Zedd", "https://charts-static.billboard.com/img/2018/02/zedd-edd-87x87.jpg"){ Id = 8 },
                    new Music("In My Feelings", "Drake", "https://charts-static.billboard.com/img/2018/07/drake-zwl-in-my-feelings-591-87x87.jpg"){ Id = 9 },
                    new Music("Girls Like You", "Maroon 5", "https://charts-static.billboard.com/img/2018/06/maroon-5-9st-girls-like-you-32b-87x87.jpg"){ Id = 10 }
                };
                music.ForEach(m => _ctx.Music.Add(m));

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
