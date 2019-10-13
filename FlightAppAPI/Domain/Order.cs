using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppAPI.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public IList<ProductOrder> ProductOrders { get; set; }
    }
}
