using FlightAppAPI.Domain;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.DTOs
{
    public class PlaceOrderDTO
    {
        public IList<OrderLineDTO> OrderLines { get; set; }

        public Order ToOrder(Passenger passenger)
        {
            return new Order(OrderLines.Select(o => o.ToOrderLine()).ToList(), passenger);
        }

        public class OrderLineDTO
        {
            public Product Product { get; set; }
            public int Amount { get; set; }


            public OrderLine ToOrderLine()
            {
                return new OrderLine(Product, Amount);
            }
        }
    }
}
