using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Models
{
    public class Leasing
    {
        public int LeasingNo { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required] 
        public int PlaceNo { get; set; }
        [Required]
        public int StudentNo { get; set; }
    }
}
