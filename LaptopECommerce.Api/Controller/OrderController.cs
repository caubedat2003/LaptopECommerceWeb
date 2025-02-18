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
        [HttpGet("Details")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderDetails()
        {
            var orders = await _context.Orders.OrderByDescending(x => x.OrderDate)
                .Include(o => o.OrderLaptops) // Include OrderLaptops
                .ThenInclude(ol => ol.Laptop) // Include Laptop for each OrderLaptop
                .ToListAsync();

            return Ok(orders);
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
                Status = Status.Pending,
                PaymentMethod = request.PaymentMethod,
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

        [HttpPut]
        [Route("{id}/assign")]
        public async Task<IActionResult> AssignShipper(Guid id, [FromBody] AssignShipperRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderFromDb = await _context.Orders.FindAsync(id);
            if(orderFromDb == null)
            {
                return NotFound("Không tìm thấy đơn hàng!");
            }

            orderFromDb.ShipperId = request.UserId.Value == Guid.Empty ? null : request.UserId.Value;
            orderFromDb.OrderId = orderFromDb.OrderId;
            orderFromDb.OrderDate = orderFromDb.OrderDate;
            orderFromDb.CustomerId = orderFromDb.CustomerId;
            orderFromDb.Status = orderFromDb.Status;
            orderFromDb.TotalAmount = orderFromDb.TotalAmount;
            orderFromDb.OrderLaptops = orderFromDb.OrderLaptops;

            _context.Orders.Update(orderFromDb);
            await _context.SaveChangesAsync();

            return Ok(orderFromDb);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _context.Orders.OrderByDescending(x => x.OrderDate)
                .Include(o => o.OrderLaptops) // Bao gồm OrderLaptops
                .ThenInclude(ol => ol.Laptop) // Bao gồm Laptop từ OrderLaptops
                .FirstOrDefaultAsync(o => o.OrderId == id); // Tìm đơn hàng theo ID

            if ( order == null)
            {
                return NotFound("Không tìm thấy đơn hàng!");
            }
            return Ok(order);
        }

        [HttpPut]
        [Route("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] StatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderFromDb = await _context.Orders.FindAsync(id);
            if (orderFromDb == null)
            {
                return NotFound("Không tìm thấy đơn hàng!");
            }

            // Cập nhật trạng thái
            orderFromDb.Status = request.Status;

            // Update các giá trị khác nếu cần giữ nguyên
            orderFromDb.OrderId = orderFromDb.OrderId;
            orderFromDb.OrderDate = orderFromDb.OrderDate;
            orderFromDb.CustomerId = orderFromDb.CustomerId;
            orderFromDb.TotalAmount = orderFromDb.TotalAmount;
            orderFromDb.OrderLaptops = orderFromDb.OrderLaptops;

            _context.Orders.Update(orderFromDb);
            await _context.SaveChangesAsync();

            return Ok(orderFromDb);
        }
        [HttpGet("MyOrder/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderByUser(Guid userId)
        {
            var orders = await _context.Orders.OrderByDescending(x => x.OrderDate)
                .Where(o => o.CustomerId == userId) // Lọc theo UserId
                .Include(o => o.OrderLaptops) // Include OrderLaptops
                .ThenInclude(ol => ol.Laptop) // Include Laptop cho từng OrderLaptop
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound($"Không tìm thấy đơn hàng nào cho UserId: {userId}");
            }

            return Ok(orders);
        }

        [HttpGet("Delivery/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderDelivery(Guid userId)
        {
            var orders = await _context.Orders.OrderByDescending(x => x.OrderDate)
                .Where(o => o.ShipperId == userId) // Lọc theo UserId
                .Include(o => o.OrderLaptops) // Include OrderLaptops
                .ThenInclude(ol => ol.Laptop) // Include Laptop cho từng OrderLaptop
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound($"Không tìm thấy đơn hàng nào cho UserId: {userId}");
            }

            return Ok(orders);
        }
    }
}
