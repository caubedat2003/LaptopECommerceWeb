using System.ComponentModel.DataAnnotations;

namespace LaptopECommerce.Api.Entities
{
    public class OrderLaptop
    {
        [Key]
        public Guid OrderLaptopId { get; set; } // Primary key for this table

        [Required]
        public Guid OrderId { get; set; } // Foreign key from the Order table
        public Order Order { get; set; } // Navigation property to Order

        [Required]
        public Guid LaptopId { get; set; } // Foreign key from the Laptop table
        public Laptop Laptop { get; set; } // Navigation property to Laptop

        [Required]
        public int Quantity { get; set; } // Quantity of this laptop in the order

        [Required]
        public int Price { get; set; } // Price at the time of purchase
    }
}
