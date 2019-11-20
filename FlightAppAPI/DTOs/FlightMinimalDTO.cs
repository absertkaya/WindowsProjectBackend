using FlightAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.DTOs
{
    public class FlightMinimalDTO
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureDest { get; set; }
        public string ArrivalDest { get; set; }

        public static FlightMinimalDTO FromFlight(Flight flight)
        {
            return new FlightMinimalDTO
            {
                Id = flight.Id,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                DepartureDest = flight.DepartureDest,
                ArrivalDest = flight.ArrivalDest
            };
        }
    }
}
