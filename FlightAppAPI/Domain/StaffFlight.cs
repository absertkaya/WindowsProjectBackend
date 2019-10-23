using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class StaffFlight
    {
        public int StaffId { get; set; }
        public int FlightId { get; set; }

        public Staff Staff { get; set; }
        public Flight Flight { get; set; }

        public IList<Announcement> Announcements { get; set; }

        public StaffFlight(Staff staff, Flight flight)
        {
            Staff = staff;
            StaffId = staff.ApplicationUserId;
            Flight = flight;
            FlightId = flight.FlightId;
            Announcements = new List<Announcement>();
        }
        
        protected StaffFlight()
        {

        }

        public void AddAnnouncement(Announcement announcement)
        {
            Announcements.Add(announcement);
        }
    }
}
