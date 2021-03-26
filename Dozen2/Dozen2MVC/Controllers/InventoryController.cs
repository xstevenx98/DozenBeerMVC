using Dozen2BL;
using Dozen2Models;
using Dozen2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryBL _inventoryBL;
        public InventoryController(IInventoryBL inventoryBL)
        {
            _inventoryBL = inventoryBL;
        }
        public IActionResult Index()
        {
            var inventories = _inventoryBL.GetInventories();
            var inventoryVMs = inventories.Select(i => new InventoryVM
            {
                DrinkID = i.DrinkID,
                DrinkName = i.Drink.DrinkName,
                Quantity = i.Quantity,
                InventoryID = i.InventoryID,
                LocationID = i.LocationID,
                LocationName = i.Location.LocationName,
                State = i.Location.State
            }).ToList();
            return View(inventoryVMs);
        }

        [HttpPost]
        public IActionResult UpdateInventories(List<InventoryVM> inventoryVMs) 
        {
            var inventories = inventoryVMs.Select(i => new Inventory
            {
                DrinkID = i.DrinkID,
                Quantity = i.Quantity,
                InventoryID = i.InventoryID,
                LocationID = i.LocationID,
            }).ToList();
            _inventoryBL.UpdateInventories(inventories);
            return RedirectToAction("Index", "Inventory");
        }
    }
}
