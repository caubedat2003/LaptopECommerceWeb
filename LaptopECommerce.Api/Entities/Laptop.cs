using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        // Quan hệ 1-n với OrderLaptop
        [JsonIgnore] // Tránh vòng lặp khi liên kết với OrderLaptop
        public virtual ICollection<OrderLaptop> OrderLaptops { get; set; }
    }
}
