using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class StaffFlight
    {
        public int StaffId { get; set; }
        public int FlightId { get; set; }

        [Required]
        public Staff Staff { get; set; }
        [Required]
        public Flight Flight { get; set; }

        public IList<Announcement> Announcements { get; set; }
        
        protected StaffFlight()
        {
            Announcements = new List<Announcement>();
        }

        public StaffFlight(Staff staff, Flight flight) : this()
        {
            Staff = staff;
            StaffId = staff.ApplicationUserId;
            Flight = flight;
            FlightId = flight.FlightId;
        }

        public void AddAnnouncement(Announcement announcement)
        {
            Announcements.Add(announcement);
        }
    }
}
