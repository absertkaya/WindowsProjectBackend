using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Passenger : ApplicationUser
    {
        public IList<PassengerFlight> PassengerFlights { get; set; }

        public Passenger()
        {
            PassengerFlights = new List<PassengerFlight>();
        }

        public void AddFlight(Flight flight, Seat seat)
        {
            PassengerFlights.Add(new PassengerFlight(this, flight, seat));
    }
    }



    
}
