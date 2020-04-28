using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    
    public class CategoryController : Controller
    {
        private ICategoryRepository _repository;
        private ProjectContext _context;
        private ILogger<CategoryController> _logger;
       
       

        public CategoryController(ICategoryRepository repository,ProjectContext context,ILogger<CategoryController> logger)
        {
            this._repository = repository;
            this._context = context;
            this._logger = logger;

        }


        public IActionResult List()
        {

            _logger.LogInformation("Category List operations"+DateTime.Now.ToString());
            return View(_repository.GetActive());
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            { 
                bool result = _repository.Add(category);
                
                
                if (result == true)
                {
                    _repository.Save();
                    _logger.LogInformation("Category Add operations success"+DateTime.Now.ToString());
                    return RedirectToAction("List","Category");
                }
                else
                {
                    TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                    _logger.LogError("Category Adding operations failed"+DateTime.Now.ToString());
                    return View(category);
                }
            }
            else
            {
                TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                _logger.LogError("Category Adding operations critically failed"+DateTime.Now.ToString());
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_repository.GetById(id));
        }


        [HttpPost]
        public IActionResult Edit(Category item)
        {
            if (ModelState.IsValid)
            {
                Category updated = _repository.GetById(item.ID);
                updated.CategoryName = item.CategoryName;
                updated.CategoryDescription = item.CategoryDescription;

                bool result = _repository.Update(updated);
                if (result)
                {
                    _repository.Save();
                   _logger.LogInformation("Category Edited"+" "+item.ID+" "+DateTime.Now.ToString());
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
                return BadRequest();
            }
        }


    
        public IActionResult Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                _repository.Remove(_repository.GetById(id));
                return RedirectToAction("List");
            }
            else
            {
                return BadRequest();
            }
         
        }

      
        public IActionResult Details(Guid id)
        {

            var category = _repository.GetById(id);
            return View(category);
        }

    

    }
}