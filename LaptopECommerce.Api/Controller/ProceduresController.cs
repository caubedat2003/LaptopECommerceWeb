using LaptopECommerce.Api.Data;
using LaptopECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopECommerce.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly LaptopDbContext _context;
        public ProceduresController(LaptopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetApples")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetApples()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandApple]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetSamsungs")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetSamsungs()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandSamsung]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetMSIs")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetMSIs()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandMSI]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetASUSs")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetASUSs()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandASUS]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetACERs")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetACERs()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandACER]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetLenovos")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetLenovos()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandLenovo]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetAlienwares")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetAlienwares()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandAlienware]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetDells")]
        public async Task<ActionResult<IEnumerable<LaptopRequest>>> GetDells()
        {
            var laptops = await _context.Laptops
                .FromSqlRaw("EXEC [dbo].[GetLaptopsByBrandDell]")
                .ToListAsync();
            return Ok(laptops);
        }

        [HttpGet]
        [Route("GetShippers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetShippers()
        {
            var users = await _context.Users
                .FromSqlRaw("EXEC [dbo].[GetShippers]")
                .ToListAsync();
            return Ok(users);
        }
    }
}
