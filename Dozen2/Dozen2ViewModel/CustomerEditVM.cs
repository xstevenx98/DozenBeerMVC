using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class CustomerEditVM
    {

        public int CustomerId { get; set; }

        [DisplayName("Full Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Age")]
        [Required]
        public string Age { get; set; }

        [DisplayName("Telephone Number")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
