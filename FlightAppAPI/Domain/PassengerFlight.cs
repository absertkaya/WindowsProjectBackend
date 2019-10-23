using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class PassengerFlight
    {
        public int PassengerFlightId { get; set; }

        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int SeatRef { get; set; }

        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public Seat Seat { get; set; }

        public IList<Message> SentMessages { get; set; }
        public IList<Message> ReceivedMessages { get; set; }
        public IList<Order> PlacedOrders { get; set; }

        public PassengerFlight(Passenger passenger, Flight flight, Seat seat)
        {
            Passenger = passenger;
            PassengerId = passenger.ApplicationUserId;

            Flight = flight;
            FlightId = flight.FlightId;

            Seat = seat;
            SeatRef = seat.SeatId;

            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
            PlacedOrders = new List<Order>();
        }

        public PassengerFlight()
        {

        }

    }
}
