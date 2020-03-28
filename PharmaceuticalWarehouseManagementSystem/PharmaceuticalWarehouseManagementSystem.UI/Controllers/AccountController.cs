using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using PharmaceuticalWarehouseManagementSystem.KERNEL.Enum;
using PharmaceuticalWarehouseManagementSystem.UI.Models;

namespace PharmaceuticalWarehouseManagementSystem.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IEmployeeRepository _repository;
        private readonly ProjectContext _context;


        public AccountController(SignInManager<IdentityUser> signInManager, IEmployeeRepository repository,
            ProjectContext context)
        {
            this.signInManager = signInManager;
            this._repository = repository;
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            List<Employee> emp = _repository.GetActive();
            bool result1 = _repository.CheckCredentials(model.Email, model.Password);

            if (result1)
            {
                if (ModelState.IsValid)
                {

                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,true,false);


                    if (result.Succeeded)
                    {
                        if (model.Role == Role.Admin)
                        {

                            return RedirectToAction("http://localhost:54127/Admin/Category/List","Category");
                         
                        }
                        else if(model.Role == Role.User)
                        {
                           
                            
                                return RedirectToAction("http://localhost:54127/User/Category/List", "Category");
                            
                        }
                        else
                        {
                            return BadRequest();
                        }
                       
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "Invalid Login attempt.");
                       
                    }

                }
                else
                {
                    return View(model);
                }

            }
            return View(model);
        }
    }
}