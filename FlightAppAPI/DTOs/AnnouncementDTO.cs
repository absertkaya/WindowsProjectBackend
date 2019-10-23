using FlightAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.DTOs
{
    public class AnnouncementDTO
    {
        public int AnnouncementId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public static AnnouncementDTO FromAnnouncement(Announcement announcement)
        {
            return new AnnouncementDTO()
            {
                AnnouncementId = announcement.AnnouncementId,
                TimeStamp = announcement.Timestamp,
                Title = announcement.Title,
                Content = announcement.Content
            };
        }
    }
}
