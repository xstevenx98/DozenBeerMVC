
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class OrderVM
    {
        public int CustomerID { get; set; }

       

        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string State { get; set; }

        public decimal Total
        {
            get;set;
        }

        public DateTime OrderDateTime { get; set; }

        public List<DrinkOrderVM> DrinkOrders { get; set; }
        public string CustomerName { get; set; }

        public OrderVM()
        {
            DrinkOrders = new List<DrinkOrderVM>();
        }
    }
}
