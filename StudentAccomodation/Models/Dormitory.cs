﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Models
{
    public class Dormitory
    {
        public int DormitoryNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        
    }
}
