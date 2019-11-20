using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.DTOs
{
    public class AnnouncementCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        public int? PassengerId { get; set; }
    }
}
