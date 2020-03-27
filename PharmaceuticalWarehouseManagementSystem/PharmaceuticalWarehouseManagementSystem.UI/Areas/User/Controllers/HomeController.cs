using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult UserHomePage()
        {
            return View("UserHomePage");
        }
    }
}