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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            _repository.Add(product);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(Guid ID)
        {
            return View(_repository.GetById(ID));
        }
        [HttpPost]
        public IActionResult Edit(Product item)
        {
            Product updated = new Product();
            
            _repository.Update(updated);
            return RedirectToAction("List");
        }
        public IActionResult Delete(Guid ID)
        {
            _repository.Remove(_repository.GetById(ID));
            return RedirectToAction("List");
        }

        public IActionResult Details(Guid id)
        {
            var product = _repository.GetById(id);
            return View(product);
        }
        
    }
}