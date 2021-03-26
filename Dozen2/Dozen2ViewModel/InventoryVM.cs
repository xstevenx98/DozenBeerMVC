using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class InventoryVM
    {
        public int InventoryID { get; set; }
        public int DrinkID { get; set; }

        public string DrinkName { get; set; }

        public int Quantity { get; set; }

        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string State { get; set; }
    }
}
