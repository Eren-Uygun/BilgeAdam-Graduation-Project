using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailRepository _repository;
        private readonly ProjectContext _context;
        private readonly ILogger<OrderDetailController> _logger;

        public OrderDetailController(IOrderDetailRepository repository,ProjectContext context,ILogger<OrderDetailController> logger)
        {
            this._repository = repository;
            this._context = context;
            this._logger  = logger;
        }
        public IActionResult List()
        {
            _logger.LogInformation("Order Details Listed "+DateTime.Now.ToString());
            return View(_repository.GetActive());
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Order> ord = new List<Order>();
            ord = _context.Orders.ToList();
            ViewBag.OrderID = ord;

            List<Product> pro = new List<Product>();
            pro = _context.Products.ToList();
            ViewBag.ProductID = pro;

            List<Shipper> ship = new List<Shipper>();
            ship = _context.Shippers.ToList();
            ViewBag.ShipperID = ship;

            return View();
        }

        [HttpPost]
        public IActionResult Add(OrderDetail item)
        {
            if (ModelState.IsValid)
            {
                bool result = _repository.Add(item);


                if (result == true)
                {
                    _repository.Save();
                    _logger.LogInformation("OrderDetail added "+item.ID+" "+DateTime.Now.ToString());
                   
                    return RedirectToAction("List");
                }
                else
                {
                   
                    _logger.LogError("Order Detail add failed"+" "+DateTime.Now.ToString());
                    return View(item);
                }
            }
            else
            {
                
                _logger.LogCritical("Order Detail add failed"+" "+DateTime.Now.ToString());
                return View(item);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(OrderDetail item)
        {
            
            if (ModelState.IsValid)
            {
                OrderDetail update = _repository.GetById(item.ID);
                update.OrderID = item.OrderID;
                update.ProductID = item.ProductID;
                update.ShipperID = item.ShipperID;
                update.UnitPrice = item.UnitPrice;
                update.Quantity = item.Quantity;
                update.Discount = item.Discount;

                bool result = _repository.Update(update);
                if (result)
                {
                    _repository.Save();
                   
                    _logger.LogInformation("OrderDetail edited "+item.ID+" "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                    _logger.LogError("OrderDetail edit operation failed"+" "+DateTime.Now.ToString());
                  
                    return View(update);
                }
            }
            else
            {
                _logger.LogCritical("OrderDetail edit operation failed"+" "+DateTime.Now.ToString());
               
                return View();
            }
        }

        public IActionResult Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Order Detail Deleted"+" "+ id+" "+DateTime.Now.ToString());
               
                _repository.Remove(_repository.GetById(id));
                return RedirectToAction("List");
            }
            else
            {
                
                _logger.LogError("OrderDetail Delete Operation Failed"+" "+DateTime.Now.ToString());
                return View();
            }
        }


    
    }
}