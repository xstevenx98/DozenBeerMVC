using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class LocationOrdersVM
    {
        public int LocationID { get; set; }

        public List<OrderVM> Orders { get; set; }
        public int SortBy { get; set; }

        public LocationOrdersVM()
        {
            Orders = new List<OrderVM>();
        }
        //locationorders depends on locationID , nullable int
       // make sure it returns no orders  when the id is null

    }
}
