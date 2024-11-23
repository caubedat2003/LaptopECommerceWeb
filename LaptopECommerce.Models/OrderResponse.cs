using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaptopECommerce.Models.Enum;

namespace LaptopECommerce.Models
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? ShipperId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public Status Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<OrderLaptopResponse> OrderLaptops { get; set; }
    }

}
