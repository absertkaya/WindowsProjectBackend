using FlightAppAPI.Domain;
using System.Collections.Generic;
using System.Linq;

namespace FlightAppAPI.DTOs
{
    public class PlaceOrderDTO
    {
        public IList<OrderLineDTO> OrderLines { get; set; }

        public class OrderLineDTO
        {
            public Product Product { get; set; }
            public int ProductId { get; set; }
            public int Amount { get; set; }
        }
    }
}
