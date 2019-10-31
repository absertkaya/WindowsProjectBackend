using FlightAppAPI.Domain;
using FlightAppAPI.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightAppAPI.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {

        private readonly ApplicationDbContext _ctx;

        public ApplicationUserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddStaff(Staff user)
        {
            _ctx.Staff.Add(user);
        }

        public void AddPassenger(Passenger user)
        {
            _ctx.Passengers.Add(user);
        }

        public Passenger GetPassengerBy(string email)
        {
            return _ctx.Passengers.FirstOrDefault(u => u.Email == email);
        }

        public Staff GetStaffBy(string email)
        {
            return _ctx.Staff.Include(s => s.Flight).FirstOrDefault(u => u.Email == email);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
