using Dozen2Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class DrinkRepoDB : IDrinkRepository
    {
        private readonly DrinkDBContext _context;
        public DrinkRepoDB (DrinkDBContext context)
        {
            _context = context;
        }

        public Drink AddDrink(Drink newDrink)
        {
            _context.Drinks.Add(newDrink);
            _context.SaveChanges();
            return newDrink;
        }

        public List<Drink> GetDrinks()
        {
            return _context.Drinks
                .AsNoTracking()
                .Select(drink => drink)
                .ToList();
        }

        public List<Drink> GetDrinksByLocation(int storeCode)
        {
            var drinkIDs = _context.Inventories.Where(i => i.LocationID == storeCode && i.Quantity > 0).Select(i => i.DrinkID).ToList();

            return _context.Drinks
                .AsNoTracking()
                .Where(drink => drinkIDs.Contains(drink.DrinkId))
                .Select(drink => drink)
                .ToList();
        }

        public Drink RemoveDrink(Drink drink2BDeleted)
        {
            _context.Drinks.Remove(drink2BDeleted);
            _context.SaveChanges();
            return drink2BDeleted;
        }
    }
}
