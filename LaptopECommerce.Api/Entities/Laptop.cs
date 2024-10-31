using System.ComponentModel.DataAnnotations;

namespace LaptopECommerce.Api.Entities
{
    public class Laptop
    {
        [Key]
        public Guid LaptopId { get; set; }
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<OrderLaptop> OrderLaptops { get; set; }
    }
}
