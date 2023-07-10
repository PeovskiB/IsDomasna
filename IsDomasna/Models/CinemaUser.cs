using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IsDomasna.Models
{
    public class CinemaUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //[Required]
        //public string Email { get; set; }
        //[Required]
        //public string Password { get; set; }

        public string? Role { get; set; }

        public int? CartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();

    }
}
