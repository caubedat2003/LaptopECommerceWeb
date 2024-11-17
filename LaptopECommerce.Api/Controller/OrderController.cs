using LaptopECommerce.Api.Data;
using LaptopECommerce.Api.Entities;
using LaptopECommerce.Models.Enum;
using LaptopECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopECommerce.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly LaptopDbContext _context;
        public OrderController (LaptopDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            if (request == null || request.Items == null || !request.Items.Any())
            {
                return BadRequest("Thông tin đơn hàng không hợp lệ.");
            }

            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = request.TotalAmount,
                Status = Status.ChuaXuLy,
                OrderLaptops = request.Items.Select(item => new OrderLaptop
                {
                    OrderLaptopId = Guid.NewGuid(),
                    LaptopId = item.LaptopId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return Ok(order.OrderId);
        }
    }
}
