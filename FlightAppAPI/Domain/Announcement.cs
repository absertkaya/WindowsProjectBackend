using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
