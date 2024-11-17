using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopECommerce.Models
{
    public class OrderItemRequest
    {
        public Guid LaptopId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
