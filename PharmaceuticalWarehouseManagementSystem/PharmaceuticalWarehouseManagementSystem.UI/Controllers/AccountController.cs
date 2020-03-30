using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;
using PharmaceuticalWarehouseManagementSystem.UI.Models;

namespace PharmaceuticalWarehouseManagementSystem.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmployeeRepository _repository;
        public AccountController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,IEmployeeRepository repository)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._repository = repository;
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken,AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,RoleModel Rmodel)
        {
            if (ModelState.IsValid)
            {
                var check = _repository.CheckCredentials(model.Username, model.Password,Rmodel.Role);

                if (check)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        model.Username, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                     
                        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    }
                    else
                    {
                        if (Rmodel.Role == Role.Admin)
                        {
                            return RedirectToAction("index", "home");
                        }
                        else if(Rmodel.Role == Role.User)
                        {
                            return RedirectToAction("index", "home");
                        }
                        else
                        {
                            return RedirectToAction("index", "home");
                        }
                    }

                 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }

              
            }

            return View(model);
        }
    }
    
}