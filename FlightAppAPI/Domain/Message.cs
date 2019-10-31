using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public Passenger Sender { get; set; }
        [Required]
        public Passenger Receiver { get; set; }

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