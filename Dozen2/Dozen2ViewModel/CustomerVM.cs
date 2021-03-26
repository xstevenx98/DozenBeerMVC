using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class CustomerVM
    {

        public int CustomerId { get; set; }

        public string Name
        { get; set; }

        public string PhoneNumber
        {
            get; set;
        }

        public string Age
        {
            get; set;
        }

    }
}
