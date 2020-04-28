using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private IOrderRepository _repository;
        private ProjectContext _context;

        public OrderController(IOrderRepository repository, ProjectContext context)
        {
            this._repository = repository;
            this._context = context;
        }
        public IActionResult List()
        {
            return View(_repository.GetActive());
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Employee> emp = new List<Employee>();
            emp = _context.Employees.ToList();
            ViewBag.EmployeeID = emp;

            List<Customer> cust = new List<Customer>();
            cust = _context.Customers.ToList();
            ViewBag.CustomerID = cust;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Order item)
        {
            if (ModelState.IsValid)
            {
                bool result = _repository.Add(item);


                if (result == true)
                {
                    _repository.Save();
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                    return View(item);
                }
            }
            else
            {
                TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                return View(item);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            List<Employee> emp = new List<Employee>();
            emp = _context.Employees.ToList();
            ViewBag.EmployeeID = emp;

            List<Customer> cust = new List<Customer>();
            cust = _context.Customers.ToList();
            ViewBag.CustomerID = cust;
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Order item)
        {
            if (ModelState.IsValid)
            {
                Order updated = _repository.GetById(item.ID);
                updated.CustomerID = item.CustomerID;
                updated.EmployeeID = item.EmployeeID;
                updated.ShippedDate = item.ShippedDate;
                updated.OrderDate = item.OrderDate;
                updated.ShipAddress = item.ShipAddress;
                updated.Freight = item.Freight;

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