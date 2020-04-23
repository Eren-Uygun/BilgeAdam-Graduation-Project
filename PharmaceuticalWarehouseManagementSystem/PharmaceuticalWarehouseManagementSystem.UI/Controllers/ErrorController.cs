using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PharmaceuticalWarehouseManagementSystem.UI.Controllers
{
    public class ErrorController : Controller
    {
        private ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
           this._logger = logger;
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("Error");
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)     
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource could not be found";
                    _logger.LogWarning($"404 error occured. Path ="+$"{statusCodeResult.OriginalPath} And QueryString = "+$"{statusCodeResult.OriginalQueryString}");
                    break;
                default:
                    break;
            }

            return View();
        }
    }
}