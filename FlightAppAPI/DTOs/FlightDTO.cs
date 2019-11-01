using FlightAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.DTOs
{
    public class FlightDTO
    {
        public int Id {get; set;}
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureDest { get; set; }
        public string ArrivalDest { get; set; }
        public IList<AnnouncementDTO> Announcements { get; set; }
        public IList<SeatDTO> Seats { get; set; }
        public IList<OrderDTO> Orders { get; set; }

        public static FlightDTO FromFlight(Flight flight)
        {
            return new FlightDTO
            {
                Id = flight.Id,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                DepartureDest = flight.DepartureDest,
                ArrivalDest = flight.ArrivalDest,
                Announcements = flight.Announcements.Select(AnnouncementDTO.FromAnnouncement).ToList(),
                Seats = flight.Seats.Select(SeatDTO.FromSeat).ToList(),
                Orders = flight.Orders.Select(OrderDTO.FromOrder).ToList()
            };
        }
    }
}
