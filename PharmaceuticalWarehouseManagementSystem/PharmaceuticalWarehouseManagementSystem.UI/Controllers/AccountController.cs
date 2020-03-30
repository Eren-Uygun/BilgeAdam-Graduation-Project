using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using PharmaceuticalWarehouseManagementSystem.UI.Models;

namespace PharmaceuticalWarehouseManagementSystem.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<LoginViewModel> _signInManager;
        private readonly UserManager<LoginViewModel> _userManager;
        private readonly IEmployeeRepository _repository;
        public AccountController(SignInManager<LoginViewModel> signInManager,UserManager<LoginViewModel> userManager,IEmployeeRepository repository)
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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _repository.CheckCredentials(model.Username, model.Password,model.Role);

                if (check)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        model.Username, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("index", "home");
                    }

                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
                else
                {
                    
                }

              
            }

            return View(model);
        }
    }
    
}