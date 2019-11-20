using FlightAppAPI.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.DTOs
{
    public class AnnouncementDTO : AnnouncementCreateDTO
    {
        [Required]
        public int AnnouncementId { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }

        public static AnnouncementDTO FromAnnouncement(Announcement announcement)
        {
            return new AnnouncementDTO()
            {
                AnnouncementId = announcement.Id,
                TimeStamp = announcement.Timestamp,
                Title = announcement.Title,
                Content = announcement.Content,
                PassengerId = announcement.Receiver?.Id
            };
        }
    }
}
