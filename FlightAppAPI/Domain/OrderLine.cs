using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class OrderLine
    {
        private int _amount = 1;

        public int Id { get; set; }
        
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Amount {
            get { return _amount; }
            set { if (value < 1) throw new ArgumentException("An order has a minimum amount of 1."); _amount = value; }
        }

        public OrderLine(Product product)
        {
            Product = product;
        }
        public OrderLine(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }
        private OrderLine() { }
    }
}