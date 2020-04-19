using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;
using PharmaceuticalWarehouseManagementSystem.UI.Models;
using System.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace PharmaceuticalWarehouseManagementSystem.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmployeeRepository _repository;
        

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            IEmployeeRepository repository)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._repository = repository;
            


        }

        [HttpPost,ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> LogOut()
        {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.LoginPath);
            HttpContext.Session.Remove("UserMail");
            HttpContext.Session.Clear();
            return Redirect("Account/Login");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Login(LoginViewModel model, RoleModel Rmodel)
        {
           


            if (ModelState.IsValid)
            {


                var check = _repository.CheckCredentials(model.UserMail, model.Password, Rmodel.Role);

                if (check)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, model.UserMail),
                        new Claim(ClaimTypes.Role, value:Rmodel.Role.ToString()),
                       
                    };

                    var userIdentity = new ClaimsIdentity(claims,"Login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                  

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);


                    if (Rmodel.Role == Role.Admin)
                    {
                        HttpContext.Session.SetString("UserMail",model.UserMail);
                        var user = await _userManager.GetUserAsync(HttpContext.User);
                        return Redirect("Admin/Category/List");
                    }
                    else if (Rmodel.Role == Role.User)
                    {
                        HttpContext.Session.SetString("UserMail",model.UserMail);
                        var user = await _userManager.GetUserAsync(HttpContext.User);
                        return Redirect("User/Category/List");
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }



                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            else
            {

                ModelState.AddModelError(string.Empty,
                    "Invalid Login Attempt,Check your email , password and role");


            }




            return View();
        }


        public IActionResult AccessDenied()
        {
            return View();
        }




    }
}

