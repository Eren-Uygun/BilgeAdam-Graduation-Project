using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "User")]
    public class SupplierController : Controller
    {
        private ISupplierRepository _repository;
        public SupplierController(ISupplierRepository repository)
        {
            this._repository = repository;
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
        public IActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                bool result =  _repository.Add(supplier);
                if (result)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View(supplier);
                }
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid ID)
        {
            return View(_repository.GetById(ID));
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
                    return RedirectToAction("List");
                }
                else
                {
                    return View(update);
                }
            }
            else
            {
                return View();
            }
        }

    }
}