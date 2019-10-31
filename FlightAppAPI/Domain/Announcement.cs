using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
        [Required]
        public Staff Sender { get; set; }

        public Announcement()
        {
            Timestamp = DateTime.Now;
        }
    }
}