using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class SupplierController : Controller
    {
        private ISupplierRepository _repository;
        private ILogger<SupplierController> _logger;

        public SupplierController(ISupplierRepository repository,ILogger<SupplierController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }
        public IActionResult List()
        {
            return View(_repository.GetActive());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Supplier item)
        {
            if (ModelState.IsValid)
            {
                bool result =  _repository.Add(item);

                if (result)
                {
                    _logger.LogInformation("Supplier added "+item.ID+" "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                    _logger.LogError("Supplier add failed "+DateTime.Now.ToString());
                    return View(item);
                }
                  
            }
            else
            {
                _logger.LogCritical("Supplier add failed "+DateTime.Now.ToString());
                return View(item);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Supplier item)
        {
            if (ModelState.IsValid)
            {
                Supplier update = _repository.GetById(item.ID);
                update.CompanyName = item.CompanyName;
                update.ContactName = item.ContactName;
                update.ContactTitle = item.ContactTitle;
                update.PhoneNumber = item.PhoneNumber;
                update.FaxNumber = item.FaxNumber;
                update.Address = item.Address;
                update.Country = item.Country;
                update.City = item.City;
                update.PostalCode = item.PostalCode;

                bool result = _repository.Update(update);
                if (result)
                {
                    _repository.Save();
                    _logger.LogInformation("Supplier Edited "+item.ID+" "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                    _logger.LogError("Supplier Edit Failed "+DateTime.Now.ToString());
                    return View(update);
                }
            }
            else
            {
                _logger.LogCritical("Supplier Edit Failed "+DateTime.Now.ToString());
                return View();
            }
        }



        public IActionResult Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Supplier Deleted"+" "+ id+" "+DateTime.Now.ToString());
                _repository.Remove(_repository.GetById(id));
                return RedirectToAction("List");
            }
            else
            {
                _logger.LogError("Supplier Delete Action Failed"+" "+DateTime.Now.ToString());
                return BadRequest();
            }
        }

   

    }
}