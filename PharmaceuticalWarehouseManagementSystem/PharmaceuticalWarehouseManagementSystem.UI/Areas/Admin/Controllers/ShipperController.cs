using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class ShipperController : Controller
    {
        private IShipperRepository _repository;
        private ILogger<ShipperController> _logger;

        public ShipperController(IShipperRepository repository,ILogger<ShipperController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }
        public IActionResult List()
        {
            _logger.LogInformation("Shippers Listed "+DateTime.Now.ToString());
            return View(_repository.GetActive());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Shipper item)
        {
            if (ModelState.IsValid)
            {
               bool result =  _repository.Add(item);

                if (result)
                {
                    _logger.LogInformation("Shipper added "+item.ID+" "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                    return View(item);
                }
                  
            }
            else
            {
                return View(item);
            }
           
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Shipper item)
        {
            if (ModelState.IsValid)
            {
                Shipper update = _repository.GetById(item.ID);
                update.CompanyName = item.CompanyName;
                update.TaxIdNumber = item.TaxIdNumber;
                update.PhoneNumber = item.PhoneNumber;
                update.Address = item.Address;
                update.Country = item.Country;
                update.City = item.City;
                update.PostalCode = item.PostalCode;

                bool result = _repository.Update(update);
                if (result)
                {
                    _logger.LogInformation("Shipper Edited "+item.ID+" "+DateTime.Now.ToString());
                    _repository.Save();
                    return RedirectToAction("List");
                }
                else
                {
                     _logger.LogError("Shipper Saving Failed "+DateTime.Now.ToString());
                    return View(update);
                }


            }
            else
            {
                _logger.LogCritical("Shipper Saving Failed "+DateTime.Now.ToString());
                return View();
            }
        }

        public IActionResult Delete(Guid id)
        {
            var shipper = _repository.GetById(id);
            _logger.LogInformation("Shipper Deleted "+id+" "+DateTime.Now.ToString());
            return View(shipper);
        }

     
    }
}