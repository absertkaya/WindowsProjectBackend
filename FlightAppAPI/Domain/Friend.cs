using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Friend
    {
        public int FriendId { get; set; }

        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passenger2 { get; set; }
        public int Passenger2Id { get; set; }
    }
}
