using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class OrderLine
    {
        private int _amount = 1;

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public Order Order { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Amount {
            get { return _amount; }
            set { if (value < 1) throw new ArgumentException("An order has a minimum amount of 1."); _amount = value; }
        }

        public OrderLine(Order order, Product product)
        {
            OrderId = order.Id;
            ProductId = product.Id;

            Order = order;
            Product = product;
        }
        private OrderLine() { }
    }
}