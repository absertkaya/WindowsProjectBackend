using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Companion
    {
        public int PassengerFlight1Id { get; set; }
        public int PassengerFlight2Id { get; set; }

        public PassengerFlight PassengerFlight1 { get; set; }
        public PassengerFlight PassengerFlight2 { get; set; }
    }
}
