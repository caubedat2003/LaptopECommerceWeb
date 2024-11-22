using LaptopECommerce.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopECommerce.Api.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        public Guid? ShipperId { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalAmount { get; set; }

        public Status Status { get; set; }
        // Quan hệ 1-n với OrderLaptop
        public virtual ICollection<OrderLaptop> OrderLaptops { get; set; }
    }
}
