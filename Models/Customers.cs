using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPanel.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Country Name")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter City Name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter City Phoneno")]     
        public string Phoneno { get; set; }

    }
}
