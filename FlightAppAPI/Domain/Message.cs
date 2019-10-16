using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public PassengerFlight Sender { get; set; }
        public int SenderId { get; set; }
        public PassengerFlight Receiver { get; set; }
        public int ReceiverId { get; set; }
    }
}
