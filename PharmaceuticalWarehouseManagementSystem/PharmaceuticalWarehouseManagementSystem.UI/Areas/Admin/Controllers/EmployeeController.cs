﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly ProjectContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EmployeeController> _logger;
        


        public EmployeeController(IEmployeeRepository repository,ProjectContext context,IHostingEnvironment hostEnvironment,IWebHostEnvironment webHostEnvironment,ILogger<EmployeeController> logger)
        {
            this._repository = repository;
            this._context = context;
            this._hostingEnvironment = hostEnvironment;
            this._webHostEnvironment = webHostEnvironment;
            this._logger = logger;
            
                
        }
        public IActionResult List()
        {
            _logger.LogInformation("Employee Listed "+DateTime.Now.ToString());
            return View(_repository.GetActive());
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee item,List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                bool imgResult;

                string imgPath = Upload.ImageUpload(Files, _hostingEnvironment, out imgResult);

              

                if (imgResult)
                {
                    item.imageUrl = imgPath;
                    TempData["Message"] = "Image Added";
                    _logger.LogInformation("Image added!!");
                }
                else
                {
                    item.imageUrl = "NULL";
                   _logger.LogWarning("Image cannot added!!");
                }





                bool result = _repository.Add(item);


                if (result == true)
                {
                    _repository.Save();
                    _logger.LogInformation("Employee Added "+item.ID+" "+DateTime.Now.ToString());
                    return RedirectToAction("List","Employee");
                }
                else
                {
                    TempData["Message"] = $"Employee Add Operation Failed";
                    _logger.LogError("Employee Add Operation "+DateTime.Now.ToString());
                    return View(item);
                }
            }
            else
            {
                TempData["Message"] = $"Employee Add Operation Failed";
                _logger.LogCritical("Employee Add Operation Failed "+DateTime.Now.ToString());
                return View(item);
            }
          
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Employee item,List<IFormFile> Files)
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

                Employee updated = _repository.GetById(item.ID);

                updated.FirstName = item.FirstName;
                updated.LastName = item.LastName;
                updated.BirthDate = item.BirthDate;
                updated.HireDate = item.HireDate;
                updated.Email = item.Email;
                updated.Password = item.Password;
                updated.PhoneNumber = item.PhoneNumber;
                updated.Address = item.Address;
                updated.Country = item.Country;
                updated.City = item.City;
                updated.imageUrl = item.imageUrl;
                updated.Role = item.Role;
                updated.PostalCode = item.PostalCode;
              



                bool result = _repository.Update(updated);
                if (result)
                {
                    _repository.Save();
                    
                    _logger.LogInformation("Employee edited "+DateTime.Now.ToString());
                    return RedirectToAction("List");
                }
                else
                {
                 
                   _logger.LogError("Employee edit operation Failed"+DateTime.Now.ToString());
                    return View(updated);
                }
            }
            else
            {
               
                 _logger.LogError("Employee edit operation failed "+DateTime.Now.ToString());
                return View();
            }



        }


        public IActionResult Delete(Guid id)
        {
            if (ModelState.IsValid)
            { 
                _logger.LogInformation("Employee Deleted"+" "+ id+" "+DateTime.Now.ToString());
             
                _repository.Remove(_repository.GetById(id));
                return RedirectToAction("List");
            }
            else
            {
                
                _logger.LogError("Employee Delete Operation Failed"+" "+DateTime.Now.ToString());
                return View();
            }
        }

        public IActionResult Details(Guid id)
        {

            var employee = _repository.GetById(id);
            
            _logger.LogInformation("Details opened "+id+" "+DateTime.Now.ToString());
            return View(employee);
        }




    

  
    }
}