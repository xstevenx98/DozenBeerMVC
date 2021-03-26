using Dozen2Models;
using System.Collections.Generic;

namespace Dozen2BL
{
    public interface IDrinkBL
    {
        List <Drink> GetDrinks();
        Drink AddDrink(Drink newDrink);

        List<Drink> GetDrinksByLocation(int storeCode);
    }
}