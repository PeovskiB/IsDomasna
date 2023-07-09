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

        //public async Task<IActionResult> ChangeUserRole()
        //{
        //    AddToRoleModel model = new AddToRoleModel();
        //    model.Roles = new List<string> { "Administrator", "Normal" };
        //    return View(model);
        //}


        //[HttpPost]
        //public async Task<IActionResult> ChangeUserRole(AddToRoleModel model)
        //{
        //    var email = model.Email;
        //    var user = await userManager.FindByEmailAsync(email);
        //    if (user == null)
        //    {
        //        throw new HttpRequestException();

        //    }

        //    await userManager.AddToRoleAsync(user, model.SelectedRole);

        //    return Redirect("/");


        //}



    }


}