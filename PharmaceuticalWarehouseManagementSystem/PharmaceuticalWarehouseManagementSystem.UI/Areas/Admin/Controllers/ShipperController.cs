using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public ShipperController(IShipperRepository repository)
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
        public IActionResult Add(Shipper item)
        {
            _repository.Add(item);
            return RedirectToAction("List");
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

        public IActionResult Delete(Guid id)
        {
            var shipper = _repository.GetById(id);
            return View(shipper);
        }
    }
}