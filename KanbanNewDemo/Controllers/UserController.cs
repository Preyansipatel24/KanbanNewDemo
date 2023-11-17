using KanbanNewDemo.DTOs.Users;
using KanbanNewDemo.Models.User;
using KanbanNewDemo.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manawork.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userService.IsUsernameExist(model.Username))
            {
                ModelState.AddModelError("Username", "Username is Exist, Please Enter other Username.");
                return View(model);
            }

            if (_userService.IsEmailExist(model.Email))
            {
                ModelState.AddModelError("Email", "Email is Exist, Please Enter other Email.");
                return View(model);
            }

            User user = new User()
            {
                Username = model.Username.ToLower(),
                Email = model.Email.ToLower(),
                IsDelete = false,
                Password = model.Password,
                RegisterDate = DateTime.Now
            };

            _userService.AddUser(user);

            return Redirect("/");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, string ReturnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userService.LoginUser(model);

            if (user != null)
            {
                var claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                };

                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = model.RememberMe
                };

                HttpContext.SignInAsync(principal, properties);

                if (ReturnUrl != "")
                {
                    return Redirect(ReturnUrl);
                }

                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("Username", "user not found!");
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
