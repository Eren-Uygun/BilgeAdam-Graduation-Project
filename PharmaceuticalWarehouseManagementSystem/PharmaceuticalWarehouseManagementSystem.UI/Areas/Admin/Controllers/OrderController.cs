using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
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
        private ILogger<OrderController> _Ilogger;

        public OrderController(IOrderRepository repository, ProjectContext context,ILogger<OrderController> logger)
        {
            this._repository = repository;
            this._context = context;
            this._Ilogger = logger;
        }
        public IActionResult List()
        {
            _Ilogger.LogInformation("Orders Listed "+DateTime.Now.ToString());
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
                    _Ilogger.LogInformation("Order Added "+" "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                    _Ilogger.LogError("Order add failed "+DateTime.Now.ToString());
                    return View(item);
                }
            }
            else
            {
                TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                _Ilogger.LogCritical("Order add failed");
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
                    _Ilogger.LogInformation("Order "+item.ID+" "+"Edited "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Message"] = $"Güncelleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin..!";
                    _Ilogger.LogError("Order Edit Error" + DateTime.Now.ToString());
                    return View(updated);
                }
            }
            else
            {
                TempData["Message"] = $"Güncelleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin..!";
                _Ilogger.LogCritical("Order Edit Error");
                return View();
            }
        }

        public IActionResult Delete(Guid id)
        {
            _repository.Remove(_repository.GetById(id));
            _Ilogger.LogInformation("Order "+id+" "+"Deleted "+DateTime.Now.ToString());
            return RedirectToAction("List");
        }

     
    }
}