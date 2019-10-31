using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Passenger : ApplicationUser
    {
        public int SeatId { get; set; }

        public IList<Order> Orders { get; set; }
        public IList<Message> SentMessages { get; set; }
        public IList<Message> ReceivedMessages { get; set; }
        public IList<Passenger> Friends { get; set; }
        [Required]
        public Seat Seat { get; set; }

        public Passenger()
        {
            Orders = new List<Order>();
            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
            Friends = new List<Passenger>();
            Type = UserType.PASSENGER;
        }
    }
}
