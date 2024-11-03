using LaptopECommerce.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LaptopECommerce.Api.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(200)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(200)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string Role {  get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
