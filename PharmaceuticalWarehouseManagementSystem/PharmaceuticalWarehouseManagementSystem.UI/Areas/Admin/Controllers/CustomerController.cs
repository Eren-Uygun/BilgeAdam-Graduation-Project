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
    public class CustomerController : Controller
    {
        private ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
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
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool result = _repository.Add(customer);

                if (result == true)
                {
                    _repository.Save();
                    return RedirectToAction("List","Customer");
                }
                else
                {
                    TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                    return View(customer);
                }
            }
            else
            {
                TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Customer item)
        {

            if (ModelState.IsValid)
            {
                Customer updated = _repository.GetById(item.ID);
                updated.CompanyName = item.CompanyName;
                updated.ContactName = item.CompanyName;
                updated.ContactTitle = item.ContactTitle;
                updated.Address = item.Address;
                updated.City = item.City;
                updated.TaxId = item.TaxId;
                updated.Country = item.Country;
                updated.Phone = item.Phone;
                updated.Fax = item.Fax;
               

                

                bool result = _repository.Update(updated);
                if (result)
                {
                    _repository.Save();
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Message"] = $"Güncelleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin..!";
                    return View(updated);
                }
            }
            else
            {
                TempData["Message"] = $"Güncelleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin..!";
                return View();
            }
        }





        public IActionResult Delete(Guid id)
        {
            _repository.Remove(_repository.GetById(id));
            return RedirectToAction("List");
        }


    }
}