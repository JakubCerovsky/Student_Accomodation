using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Models
{
    public class Apartment
    {
        public int ApartmentNo { get; set; }
        [Required]
        public string Address { get; set; }
        public string Types { get; set; }
    }
}
