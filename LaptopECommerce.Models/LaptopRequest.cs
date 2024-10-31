using System.ComponentModel.DataAnnotations;

namespace LaptopECommerce.Models
{
    public class LaptopRequest
    {
        public Guid LaptopId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
