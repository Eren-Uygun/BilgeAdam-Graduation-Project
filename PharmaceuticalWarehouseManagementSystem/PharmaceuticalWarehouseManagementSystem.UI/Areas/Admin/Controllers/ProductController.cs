using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using PharmaceuticalWarehouseManagementSystem.Utility;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        private ICategoryRepository _categoryRepository;
        private ISupplierRepository _supplierRepository;
        private ProjectContext _context;
        private ILogger<ProductController> _logger;
        private IHostingEnvironment _hostingEnvironment;



        public ProductController(IProductRepository repository,ICategoryRepository categoryRepository,ISupplierRepository supplierRepository,ProjectContext context,ILogger<ProductController> logger,IHostingEnvironment hostingEnvironment)
        {
            this._repository = repository;
            this._categoryRepository = categoryRepository;
            this._supplierRepository = supplierRepository;
            this._context = context;
            this._logger = logger;
            this._hostingEnvironment = hostingEnvironment;



        }
        public IActionResult List()
        {
            List<Category> upli = new List<Category>();
            upli = _context.Categories.ToList();
            ViewBag.ListOfCategories = upli;


            List<Supplier> upsup = new List<Supplier>();
            upsup = _context.Suppliers.ToList();
            ViewBag.ListOfSuppliers = upsup;
           
            return View(_repository.GetActive());
        }

        public IActionResult Add()
        {
            List<Category> li = new List<Category>();
            li = _context.Categories.ToList();
            ViewBag.ListOfCategories = li;


            List<Supplier> sup = new List<Supplier>();
            sup = _context.Suppliers.ToList();
            ViewBag.ListOfSuppliers = sup;



            return View();
        }

        [HttpPost]
        public IActionResult Add(Product item,List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                bool imgResult;

                string imgPath = Upload.ImageUpload(Files, _hostingEnvironment, out imgResult);

              

                if (imgResult)
                {
                    item.imageUrl = imgPath;
                    _logger.LogInformation("Image added!!");
                }
                else
                {
                    item.imageUrl = "NULL";
                   _logger.LogWarning("Image cannot added!!");
                }


                bool result = _repository.Add(item);

                if (result)
                {
                      _logger.LogInformation("Product added "+item.ID+" "+DateTime.Now.ToString());
                       return RedirectToAction("List");
                }
                else
                {
                     TempData["Message"] = $"Kayıt işlemi sırasında bir hata oluştu. Lütfen tüm alanları kontrol edip tekrar deneyin..!";
                    _logger.LogError("Employee Saving Failed "+DateTime.Now.ToString());
                    return View(item);
                }
              
            }
            else
            {
                return View();
            }
           
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            List<Category> upli1 = new List<Category>();
            upli1 = _context.Categories.ToList();
            ViewBag.ListOfCategories = upli1;


            List<Supplier> upsup1 = new List<Supplier>();
            upsup1 = _context.Suppliers.ToList();
            ViewBag.ListOfSuppliers = upsup1;


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
                     _logger.LogInformation("Product Edited "+item.ID+" "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Message"] = $"Güncelleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin..!";
                    _logger.LogError("Product Edit Failed "+DateTime.Now.ToString());
                    return View(updated);
                }
            }
            else
            {
                TempData["Message"] = $"Güncelleme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin..!";
                _logger.LogCritical("Product Edit Failed "+DateTime.Now.ToString());
                return View();
            }
        }


        public IActionResult Delete(Guid id)
        {
            _repository.Remove(_repository.GetById(id));
            _logger.LogInformation(id + " Deleted " + DateTime.Now.ToString());
            return RedirectToAction("List");
        }

        public IActionResult Details(Guid id)
        {
            var product = _repository.GetById(id);
            _logger.LogInformation("Details opened "+id+" "+DateTime.Now.ToString());
            return View(product);
        }


   
    }
}