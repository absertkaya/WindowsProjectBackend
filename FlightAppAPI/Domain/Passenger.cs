using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FlightAppAPI.Domain
{
    public class Passenger : ApplicationUser
    {
        public int SeatId { get; set; }

        public IList<Order> Orders { get; set; }
        public IList<Message> SentMessages { get; set; }
        public IList<Message> ReceivedMessages { get; set; }
        public IList<Friend> Friends { get; set; }
        public IList<Announcement> ReceivedAnnouncements { get; set; }
        [Required]
        public Seat Seat { get; set; }

        public Passenger()
        {
            Orders = new List<Order>();
            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
            Friends = new List<Friend>();
            Type = UserType.PASSENGER;
        }

        public void AddFriend(Passenger passenger)
        {
            if (Friends.FirstOrDefault(p => p.Passenger2 == passenger || p.Passenger == passenger) == null)
            {
                Friends.Add(new Friend() { Passenger = this, Passenger2 = passenger, PassengerId = this.Id, Passenger2Id = passenger.Id });
            }
        }
    }
}
