using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {

        private readonly ApplicationDbContext _ctx;

        public ApplicationUserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(ApplicationUser user)
        {
            _ctx.ApplicationUsers.Add(user);
        }

        public ApplicationUser GetBy(string email)
        {
            return _ctx.ApplicationUsers.FirstOrDefault(u => u.Email == email);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
