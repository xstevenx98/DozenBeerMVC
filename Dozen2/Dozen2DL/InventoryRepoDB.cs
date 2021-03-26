
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class InventoryRepoDB : IInventoryRepo
    {
        private DrinkDBContext _context;

        public InventoryRepoDB(DrinkDBContext context)
        {
            _context = context;
            
        }

        public Dozen2Models.Drink GetDrinkByName(string drinkName) 
        {
            return _context.Drinks.Where(i => i.DrinkName == drinkName).FirstOrDefault();
           
        }

        public List<Dozen2Models.Location> GetAvailableLocations(string drinkName, int drinkQuantityNumber)
        {
            var locations = new List<Dozen2Models.Location>();
            var drink = _context.Drinks.Where(i => i.DrinkName == drinkName).FirstOrDefault();
            if (drink == null)
            {
                return locations;
            }
            else
            {
                var entityInventories = _context.Inventories.Where(i => i.DrinkID == drink.DrinkId && i.Quantity >= drinkQuantityNumber).ToList();
                var locationIDs = entityInventories.Select(i => i.LocationID).ToList();
               return  _context.Locations.Where(i => locationIDs.Contains(i.LocationID)).ToList();
            
            }
        }

        public List<Dozen2Models.Inventory> GetLocationInventories(int locationID)
        {
            /*.include is for subtables*/

            return _context.Inventories
                .Include("Drink")
                .Include("Location")
                .Where(i => i.LocationID == locationID).ToList();
           
        }

        public List<Dozen2Models.Inventory> GetInventories()
        {
            return _context.Inventories
                 .Include("Drink")
                 .Include("Location")
                 .ToList();
        }

        public void UpdateInventories(List<Dozen2Models.Inventory> inventories)
        {
            _context.Inventories.UpdateRange(inventories);
            _context.SaveChanges();
        }

        public Dozen2Models.Inventory GetInventoryByLocationIDAndDrinkID(int locationID, int drinkId)
        {
            return _context.Inventories.Where(i => i.LocationID == locationID && i.DrinkID == drinkId).FirstOrDefault();
        }

        public void UpdateInventory(Dozen2Models.Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            _context.SaveChanges();
        }
    }
}
