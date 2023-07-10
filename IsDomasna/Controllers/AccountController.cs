using IsDomasna.Models.DTOs;
using IsDomasna.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LabIS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CinemaUser> userManager;
        private readonly SignInManager<CinemaUser> signInManager;
        public AccountController(UserManager<CinemaUser> userManager, SignInManager<CinemaUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    var user = new CinemaUser
                    {
                        FirstName = request.Name,
                        LastName = request.LastName,
                        Email = request.Email,
                        //UserCart = new ShoppingCart(),
                    };
                    var result = await userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(request);
                }
            }
            return View(request);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            //return RedirectToAction("Login", "Account");
            return Redirect("https://localhost:7118/Identity/Account/Login");
        }


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult ChangePermissions(string userId)
        {
            var user = userManager.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserPermissionsDto
            {
                UserId = userId,
                UserName = user.UserName,
                CurrentRole = userManager.GetRolesAsync(user).Result.FirstOrDefault()
            };

            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangePermissions(UserPermissionsDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);

                if (user == null)
                {
                    return NotFound();
                }

                var currentRole = await userManager.GetRolesAsync(user);
                var currentRoleName = currentRole.FirstOrDefault();

                if (currentRoleName == model.CurrentRole)
                {
                    await userManager.RemoveFromRoleAsync(user, currentRoleName);
                    await userManager.AddToRoleAsync(user, model.NewRole);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("message", "The current role selected is incorrect.");
                }
            }

            return View(model);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult ManagePermissions()
        {
            var users = userManager.Users.ToList();
            var model = users.Select(user => new CinemaUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = userManager.GetRolesAsync(user).Result.FirstOrDefault()
            }).ToList();

            return View(model);
        }




    }


}


