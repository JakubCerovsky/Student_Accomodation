using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Models
{
    public class Room
    {       
        public int PlaceNo { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int RentPerSemester { get; set; }
        [Required]
        public bool Occupied { get; set; }
        public int DormitoryNo { get; set; }
        public int ApartmentNo { get; set; }
    }
}
