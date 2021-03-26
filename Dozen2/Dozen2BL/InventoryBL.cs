using Dozen2DL;
using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2BL
{
    public class InventoryBL : IInventoryBL
    {
        private IInventoryRepo _inventoryRepo;

        public InventoryBL(IInventoryRepo inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        public List<Location> GetAvailableLocations(string drinkName, int drinkQuantityNumber)
        {
            return _inventoryRepo.GetAvailableLocations(drinkName, drinkQuantityNumber);
        }

        public Drink GetDrinkByName(string drinkName)
        {
            return _inventoryRepo.GetDrinkByName(drinkName);
        }

        public List<Inventory> GetInventories()
        {
            return _inventoryRepo.GetInventories();
        }

        public Inventory GetInventoryByLocationIDAndDrinkID(int locationID, int drinkId)
        {
            return _inventoryRepo.GetInventoryByLocationIDAndDrinkID(locationID, drinkId);
        }

        public List<Inventory> GetLocationInventories(int locationID)
        {
            return _inventoryRepo.GetLocationInventories(locationID);
        }

        public void UpdateInventories(List<Inventory> inventories)
        {
            _inventoryRepo.UpdateInventories(inventories);
        }

        public void UpdateInventory(Inventory inventory)
        {
            _inventoryRepo.UpdateInventory(inventory);
        }
    }
}
