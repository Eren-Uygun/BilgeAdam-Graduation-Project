using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }
        public IActionResult List()
        {
            return View(_repository.GetActive());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product item)
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
        public IActionResult Edit(Product item)
        {
            if (ModelState.IsValid)
            {
                Product updated = _repository.GetById(item.ID);
                updated.CategoryID = item.CategoryID;
                updated.SupplierID = item.SupplierID;
                updated.ProductName = item.ProductName;
                updated.QuantityPerUnit = item.QuantityPerUnit;
                updated.UnitPrice = item.UnitPrice;
                updated.UnitsInStock = item.UnitsInStock;
                updated.ReorderLevel = item.ReorderLevel;
                updated.ExpiredDate = item.ExpiredDate;
                updated.Discontinued = item.Discontinued;

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

        public IActionResult Details(Guid id)
        {
            var product = _repository.GetById(id);
            return View(product);
        }
    }
}