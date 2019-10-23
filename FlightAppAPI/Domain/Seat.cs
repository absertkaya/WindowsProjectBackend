using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int SeatNr { get; set; }
        public ClassType ClassType { get; set; }
        public PassengerFlight Passenger { get; set; }
    }
}
