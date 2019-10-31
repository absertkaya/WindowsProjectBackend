using System.Collections.Generic;

namespace FlightAppAPI.Domain
{
    public class Staff : ApplicationUser
    {
        public IList<Announcement> SentAnnouncements { get; set; }
        public Flight Flight { get; set; }
        public Staff()
        {
            SentAnnouncements = new List<Announcement>();
            Type = UserType.STAFF;
        }
    }
}
