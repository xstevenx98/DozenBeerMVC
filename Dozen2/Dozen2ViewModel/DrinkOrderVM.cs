using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class DrinkOrderVM
    {
        public int Quantity { get; set; }
        public int DrinkId { get; set; }

        public string DrinkName
        {
            get; set;
        }

        public int ABV
        {
            get;set;
        }

        public decimal Price
        {
            get;set;
        }
    }
}
