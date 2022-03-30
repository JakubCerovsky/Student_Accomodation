using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Interfaces
{
    public interface IDormitoryService
    {
        IEnumerable<Dormitory> GetAllDormitories();

        IEnumerable<Room> GetVacantRoomsDormitory(int dormitory);
    }
}
