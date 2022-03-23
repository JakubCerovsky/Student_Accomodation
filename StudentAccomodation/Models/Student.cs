using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Models
{
    public class Student
    {
        public int StudentNo { get; set; }
        [Required]
        public string SName { get; set; }
        [Required]
        public string SAddress { get; set; }
        [Required]
        public bool HasRent { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
