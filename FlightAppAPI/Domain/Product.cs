using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAppAPI.Domain
{
    public class Product
    {
        private decimal _price;

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public decimal Price {
            get { return _price; }
            set { if (value <= 0) throw new ArgumentException("Product price can't be 0 or negative."); _price = value; }
        }
        [Required]
        public ProductType Type { get; set; }
    }
}
