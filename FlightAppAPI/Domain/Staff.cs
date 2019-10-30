using System.Collections.Generic;

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
            Type = UserType.STAFF;
        }

        public void AddFlight(Flight flight)
        {
            StaffFlights.Add(new StaffFlight(this, flight));
        }
    }
}
