using System.Collections.Generic;
using System.Threading.Tasks;
using IsDomasna.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IsDomasna.Pages
{
    //[Authorize(Roles = "Admin")] // Restrict access to this page to users with the "Admin" role
    [Authorize]
    public class ManageRolesController : PageModel
    {
        private readonly UserManager<CinemaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageRolesController(UserManager<CinemaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<CinemaUser> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAssignRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Remove existing roles from the user
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);

            // Add the new role to the user
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToPage();
        }
    }
}
