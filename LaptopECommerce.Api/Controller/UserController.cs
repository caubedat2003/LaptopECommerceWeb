using LaptopECommerce.Api.Data;
using LaptopECommerce.Api.Entities;
using LaptopECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopECommerce.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LaptopDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserController (LaptopDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RegisterResponse
                {
                    Successful = false,
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage))
                });
            }
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Gender = request.Gender,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
                Role = request.Role,
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new RegisterResponse
                {
                    Successful = false,
                    Errors = result.Errors.Select(e => e.Description)
                });
            }
            return Ok(new RegisterResponse { Successful = true });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userFromDb = await _context.Users.FindAsync(id);

            if(userFromDb == null)
            {
                return NotFound();
            }

            userFromDb.FirstName = request.FirstName;
            userFromDb.LastName = request.LastName;
            userFromDb.Email = request.Email;
            userFromDb.Gender = request.Gender;
            userFromDb.Address = request.Address;
            userFromDb.PhoneNumber = request.PhoneNumber;
            userFromDb.Role = request.Role;
            userFromDb.DateOfBirth = request.DateOfBirth;
            if (request.isChangePass == true)
            {
                userFromDb.PasswordHash = _userManager.PasswordHasher.HashPassword(userFromDb, request.Password);
            }
            else
            {
                userFromDb.PasswordHash = userFromDb.PasswordHash;
            }

            _context.Users.Update(userFromDb);
            await _context.SaveChangesAsync();

            return Ok(userFromDb);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
