using LaptopECommerce.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopECommerce.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Gender Gender  { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public bool isChangePass {  get; set; }
    }
}
