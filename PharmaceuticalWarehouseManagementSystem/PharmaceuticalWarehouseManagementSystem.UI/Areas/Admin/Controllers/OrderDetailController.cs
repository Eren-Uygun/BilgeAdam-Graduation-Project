using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderDetailController : Controller
    {
        private IOrderDetailRepository _repository;

        public OrderDetailController(IOrderDetailRepository repository)
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
        public IActionResult Add(OrderDetail item)
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