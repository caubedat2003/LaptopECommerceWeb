using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopECommerce.Models
{
    public class OrderLaptopResponse
    {
        public Guid OrderLaptopId { get; set; }
        public Guid OrderId { get; set; }
        public Guid LaptopId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public LaptopResponse Laptop { get; set; }
    }
}
