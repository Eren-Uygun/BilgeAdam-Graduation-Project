using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        [Area("Admin")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
        public class HomeController : Controller
        {
            public IActionResult AdminHomePage()
            {
                return View("AdminHomePage");
            }
        }
    }
}