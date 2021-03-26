using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public interface IInventoryRepo
    {
        public Dozen2Models.Drink GetDrinkByName(string drinkName);
        public List<Dozen2Models.Location> GetAvailableLocations(string drinkName, int drinkQuantityNumber);

        public List<Dozen2Models.Inventory> GetLocationInventories(int locationID);
        List<Inventory> GetInventories();
        void UpdateInventories(List<Inventory> inventories);
        Inventory GetInventoryByLocationIDAndDrinkID(int locationID, int drinkId);
        void UpdateInventory(Inventory inventory);
    }
}
