using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        
        public IList<OrderLine> OrderLines { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        public Passenger Customer { get; set; }

        public Order()
        {
            OrderLines = new List<OrderLine>();
            OrderStatus = OrderStatus.PENDING;
        }
    }
}
