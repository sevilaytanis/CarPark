using AspNetCore.Identity.MongoDbCore.Models;
using CarPark.Entities.Concrete;
using CarPark.Models.RequestModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Employee> _userManager;

        private readonly SignInManager<Employee> _signInManager;

        private readonly RoleManager<MongoIdentityRole> _roleManager;

        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, RoleManager<MongoIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterCreateModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCreateModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                //
                var employe = new Employee
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = "2121221212"
                };


                var result = await _userManager.CreateAsync(employe, model.Password);

                if (result.Succeeded)
                {
                    var role = new MongoIdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    };

                    var resultRole = await _roleManager.CreateAsync(role);

                    await _userManager.AddToRoleAsync(employe, "admin");

                    await _signInManager.SignInAsync(employe, false);

                    return RedirectToLocal(returnUrl);
                }
            }

            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
        }



        public IActionResult Login(string _returnUrl = null)
        {
            ViewData["ReturnUrl"] = _returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (loginResult.Succeeded)
                {
                    return RedirectToLocal(returnUrl);

                }
            }
            return View(model);
        }

        public IActionResult LogOut(string _returnUrl = null)
        {
            ViewData["ReturnUrl"] = _returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOut(LoginModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
               await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AcessDenied()
        {

            return View();
        }
    }

}
