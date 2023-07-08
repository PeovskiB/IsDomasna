using Microsoft.AspNetCore.Identity;

namespace IsDomasna.Models
{
    public class CinemaUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
