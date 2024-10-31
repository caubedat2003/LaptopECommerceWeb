using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LaptopECommerce.Api.Entities
{
    public class Role : IdentityRole<Guid>
    {
        [MaxLength(200)]
        [Required]
        public string Description { get; set; }
    }
}
