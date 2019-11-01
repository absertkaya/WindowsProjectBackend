using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightAppAPI.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        #region Init
        private readonly ApplicationDbContext _ctx;
        
        public ApplicationUserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        #endregion

        public void AddUser(ApplicationUser user)
        {
            if(user.Type.Equals(UserType.PASSENGER)) _ctx.Passengers.Add((Passenger) user);
            else _ctx.Staff.Add((Staff) user);
            _ctx.SaveChanges();
        }

        public ApplicationUser GetUserBy(string email)
        {
            ApplicationUser user = _ctx.ApplicationUsers.FirstOrDefault(u => u.Email.ToUpper().Equals(email.ToUpper()));
            if (user is null) return null;
            if (user.Type.Equals(UserType.PASSENGER)) return _ctx.Passengers.Include(p => p.Seat).ThenInclude(s => s.Flight).FirstOrDefault(u => u.Email.ToUpper().Equals(email.ToUpper()));
            return _ctx.Staff.Include(s => s.Flight).FirstOrDefault(u => u.Email == email);
        }
    }
}
