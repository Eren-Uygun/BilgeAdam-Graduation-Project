using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaceuticalWarehouseManagementSystem.ENTITY.Entity;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;

namespace PharmaceuticalWarehouseManagementSystem.UI.Areas.User.Controllers
{
    [Area("User")]
    public class ShipperController : Controller
    {
        private IShipperRepository _repository;
        public ShipperController(IShipperRepository repository)
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
        public IActionResult Add(Shipper shipper)
        {
            _repository.Add(shipper);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(Guid ID)
        {
            return View(_repository.GetById(ID));
        }
        [HttpPost]
        public IActionResult Edit(Shipper item)
        {
            return View();
        }

        public IActionResult Delete(Guid ID)
        {
            _repository.Remove(_repository.GetById(ID));
            return RedirectToAction("List");
        }
    }
}