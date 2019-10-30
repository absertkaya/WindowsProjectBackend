using System.Collections.Generic;

namespace FlightAppAPI.Domain
{
    public class Passenger : ApplicationUser
    {
        public IList<PassengerFlight> PassengerFlights { get; set; }

        public Passenger()
        {
            PassengerFlights = new List<PassengerFlight>();
            Type = UserType.PASSENGER;
        }

        public void AddFlight(Flight flight, Seat seat)
        {
            PassengerFlights.Add(new PassengerFlight(this, flight, seat));
        }
    }
}
