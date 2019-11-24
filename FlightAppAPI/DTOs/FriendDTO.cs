using FlightAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.DTOs
{
    public class FriendDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }

        public static FriendDTO FromPassenger(Passenger passenger)
        {
            return new FriendDTO
            {
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName, 
                Picture = "https://imgur.com/a/Frp3XR3"
            };
        }
    }
}
