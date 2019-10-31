using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        [MaxLength(200)]
        public string DepartureDest { get; set; }
        [Required]
        [MaxLength(200)]
        public string ArrivalDest { get; set; }

        public IList<Announcement> Announcements { get; set; }
        public IList<Seat> Seats { get; set; }
        public IList<Staff> Staff { get; set; }
        public IList<Order> Orders { get; set; }

        public Flight()
        {
            Announcements = new List<Announcement>();
            Seats = new List<Seat>();
            Staff = new List<Staff>();
        }
    }
}