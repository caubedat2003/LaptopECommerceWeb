using LaptopECommerce.Api.Data;
using LaptopECommerce.Api.Entities;
using LaptopECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopECommerce.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly LaptopDbContext _context;
        public LaptopController(LaptopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laptop>>> GetAll()
        {
            return await _context.Laptops.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Laptop>> GetById(Guid id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return laptop;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LaptopRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var laptop = new Laptop
            {
                LaptopId = Guid.NewGuid(),
                Name = request.Name,
                Brand = request.Brand,
                CPU = request.CPU,
                GraphicsCard = request.GraphicsCard,
                CreatedDate = DateTime.Now,
                ImageURL = request.ImageURL,
                Price = request.Price,
                RAM = request.RAM,
                Storage = request.Storage
            };

            _context.Laptops.Add(laptop);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = laptop.LaptopId }, laptop);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LaptopRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var laptopFromDb = await _context.Laptops.FindAsync(id);

            if (laptopFromDb == null)
            {
                return NotFound("Laptop not found!");
            }

            laptopFromDb.Name = request.Name;
            laptopFromDb.Brand = request.Brand;
            laptopFromDb.CPU = request.CPU;
            laptopFromDb.Storage = request.Storage;
            laptopFromDb.GraphicsCard = request.GraphicsCard;
            laptopFromDb.ImageURL = request.ImageURL;
            laptopFromDb.Price = request.Price;
            laptopFromDb.RAM = request.RAM;

            _context.Laptops.Update(laptopFromDb);
            await _context.SaveChangesAsync(); // Add this line

            return Ok(laptopFromDb);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var laptopFromDb = await _context.Laptops.FindAsync(id);
            if (laptopFromDb == null)
            {
                return NotFound();
            }
            _context.Laptops.Remove(laptopFromDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Laptop>>> SearchLaptops([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await _context.Laptops.ToListAsync(); // Nếu không có từ khóa, trả về toàn bộ danh sách.
            }

            var laptops = await _context.Laptops
                .Where(l => l.Name.Contains(name)) // Tìm laptop có tên chứa từ khóa
                .ToListAsync();

            return laptops;
        }
    }
}
