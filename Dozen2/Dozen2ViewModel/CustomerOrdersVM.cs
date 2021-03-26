using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class CustomerOrdersVM
    {
        public int CustomerID { get; set; }

        public List<OrderVM> Orders { get; set; }
        public int  SortBy { get; set; }

        public CustomerOrdersVM()
        {
            Orders = new List<OrderVM>();
            SortBy = 1;
        }

        


    }
}
