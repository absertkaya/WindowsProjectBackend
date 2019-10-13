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

                string email = "staff1@gmail.com";
                Staff staff1 = new Staff() {Email = email, BirthDate=DateTime.Parse("10/05/1996"), LastName = "Sertkaya", FirstName = "Abdullah" };
                await CreateUser(email, "Password1*");

                email = "staff2@gmail.com";
                Staff staff2 = new Staff() { Email = email, BirthDate = DateTime.Parse("10/05/1996"), LastName = "Opalfvens", FirstName = "Bono" };
                await CreateUser(email, "Password1*");

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
