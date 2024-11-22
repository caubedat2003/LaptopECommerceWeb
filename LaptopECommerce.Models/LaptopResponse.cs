using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopECommerce.Models
{
    public class LaptopResponse
    {
        public Guid LaptopId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
