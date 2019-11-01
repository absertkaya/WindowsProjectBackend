using FlightAppAPI.Domain;
using System;
using System.Collections.Generic;

namespace FlightAppAPI.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public IList<OrderLine> OrderLines { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PassengerMinimal Customer { get; set; }

        public class PassengerMinimal
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int SeatNr { get; set; }
        }

        public static OrderDTO FromOrder(Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                Timestamp = order.Timestamp,
                OrderLines = order.OrderLines,
                OrderStatus = order.OrderStatus,
                Customer = new PassengerMinimal {
                    FirstName = order.Customer.FirstName,
                    LastName = order.Customer.LastName,
                    SeatNr = order.Customer.Seat.Nr
                }
            };
        }
    }
}
