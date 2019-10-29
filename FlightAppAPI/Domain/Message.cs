using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Message
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [Required]
        public PassengerFlight Sender { get; set; }
        [Required]
        public PassengerFlight Receiver { get; set; }

        public int MessageId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        public Message()
        {
            Timestamp = DateTime.Now;
        }
    }
}