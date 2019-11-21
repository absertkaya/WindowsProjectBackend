using FlightAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.DTOs
{
    public class PassengerDTO
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Friend> Friends { get; set; }
        public int SeatNr { get; set; }
        public ClassType SeatClass { get; set; }
        public int FlightId { get; set; }
        public UserType Type { get; set; }
        public List<OrderDTO> Orders { get; set; }

        public static PassengerDTO FromPassenger(Passenger passenger)
        {
            return new PassengerDTO
            {
                Id = passenger.Id,
                BirthDate = passenger.BirthDate,
                Email = passenger.Email,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                Friends = passenger.Friends,
                SeatNr = passenger.Seat.Nr,
                SeatClass = passenger.Seat.ClassType,
                FlightId = passenger.Seat.Flight.Id,
                Type = passenger.Type,
                Orders = passenger.Orders.Select(o => OrderDTO.FromOrder(o)).ToList()
            };
        }
        public static PassengerDTO FromStaff(Staff passenger)
        {
            return new PassengerDTO
            {
                Id = passenger.Id,
                BirthDate = passenger.BirthDate,
                Email = passenger.Email,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                FlightId = passenger.Flight.Id,
                Type = passenger.Type
            };
        }
    }
}
