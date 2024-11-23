using LaptopECommerce.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopECommerce.Models
{
    public class OrderRequest
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemRequest> Items { get; set; }
        public int TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
