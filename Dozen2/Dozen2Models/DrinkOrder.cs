using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2Models
{
    public class DrinkOrder
    {
        public int DrinkOrderId { get; set; }
        public int OrderId { get; set; }
        /*
         virtual is a convenient way to query its relevent roles 
        when I create this order tabel I plan to have a drinkid and its purpose is a FK for drink 
        drinkID is a key to locker and drink is actual locker 

         */
        public virtual Order Order { get; set; }
       
        public virtual Drink Drink { get; set; }
        public int Quantity { get; set; } 
        public int DrinkId { get; set; }


    }
}
