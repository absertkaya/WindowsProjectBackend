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

        public Staff()
        {
            HandledOrders = new List<Order>();
            StaffFlights = new List<StaffFlight>();
        }

        public void AddFlight(Flight flight)
        {
            StaffFlights.Add(new StaffFlight(this, flight));
        }
    }
}
