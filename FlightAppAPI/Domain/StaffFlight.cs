using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class StaffFlight
    {
        public int StaffId { get; set; }
        public int FlightId { get; set; }

        public Staff Staff { get; set; }
        public Flight Flight { get; set; }
    }
}
