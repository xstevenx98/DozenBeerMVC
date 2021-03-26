using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    /// <summary>
    /// model for the index view of my app
    /// </summary>
    public class CustomerIndexVM
    {
        public string SearchName { get; set; }
        public List<CustomerVM> Customers { get; set; }
    }
}
