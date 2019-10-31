using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Seat
    {
        public int Id { get; set; }
        [Required]
        public int Nr { get; set; }
        [Required]
        public ClassType ClassType { get; set; }
        public Passenger Passenger { get; set; }
        [Required]
        public Flight Flight { get; set; }
    }
}
