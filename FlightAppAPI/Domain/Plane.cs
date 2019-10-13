using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public IList<Seat> Seats { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
