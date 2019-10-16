using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Staff : ApplicationUser
    {
        
        public IList<Order> HandledOrders { get; set; }

        public IList<StaffFlight> StaffFlights { get; set; }
    }
}
