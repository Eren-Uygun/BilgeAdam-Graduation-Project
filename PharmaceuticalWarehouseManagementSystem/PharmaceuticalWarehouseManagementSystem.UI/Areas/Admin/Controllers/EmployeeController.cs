using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
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
        public IActionResult Add(Employee item)
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
        public IActionResult Edit(Employee item)
        {
            if (ModelState.IsValid)
            {
                Employee updated = _repository.GetById(item.ID);

                updated.FirstName = item.FirstName;
                updated.LastName = item.LastName;
                updated.BirthDate = item.BirthDate;
                updated.HireDate = item.HireDate;
                updated.Email = item.Email;
                updated.Password = item.Password;
                updated.CellPhoneNumber = item.CellPhoneNumber;
                updated.HomePhoneNumber = item.HomePhoneNumber;
                updated.Address = item.Address;
                updated.Country = item.Country;
                updated.Region = item.Region;
                updated.City = item.City;
                updated.Notes = item.Notes;
                updated.Role = item.Role;
                updated.PostalCode = item.PostalCode;
                updated.Photo = item.Photo;



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
    }
}