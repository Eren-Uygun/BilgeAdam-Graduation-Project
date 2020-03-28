using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.User.Controllers
{
    [Area("User")]
   public class OrderDetailController : Controller
    {
        private IOrderDetailRepository _repository;
        private ProjectContext _context;

        public OrderDetailController(IOrderDetailRepository repository,ProjectContext context)
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
            _repository.Remove(_repository.GetById(id));
            return RedirectToAction("List");
        }
    }
}