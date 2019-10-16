using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Passenger : ApplicationUser
    {
        public IList<PassengerFlight> PassengerFlights { get; set; }
    }
}
