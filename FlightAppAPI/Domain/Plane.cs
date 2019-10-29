using System.Collections.Generic;

namespace FlightAppAPI.Domain
{
    public class Plane
    {
        public int PlaneId { get; set; }

        public IList<Seat> Seats { get; set; }
        public IList<Flight> Flights { get; set; }

        public Plane()
        {
            Seats = new List<Seat>();
            Flights = new List<Flight>();
        }
    }
}
