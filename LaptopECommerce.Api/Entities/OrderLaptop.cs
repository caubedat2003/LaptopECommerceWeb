using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LaptopECommerce.Api.Entities
{
    public class OrderLaptop
    {
        [Key]
        public Guid OrderLaptopId { get; set; } // Primary key for this table

        public Guid OrderId { get; set; } // Foreign key from the Order table
        public Guid LaptopId { get; set; } // Foreign key from the Laptop table
        public int Quantity { get; set; } // Quantity of this laptop in the order
        public int Price { get; set; } // Price at the time of purchase
        [JsonIgnore] // Để tránh vòng lặp tuần hoàn , Navigation properties
        public virtual Order Order { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
