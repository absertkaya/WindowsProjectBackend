using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain.IRepositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetBy(string email);
        void Add(ApplicationUser user);
        void SaveChanges();
    }
}
