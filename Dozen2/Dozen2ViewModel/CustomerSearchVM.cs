using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Models
{
    public class CustomerSearchVM
    {
        [DisplayName("Full Name")]
        [Required]
        public string Name { get; set; }
    }
}
