using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.DormitoryService
{
    public class DormitoryService:IDormitoryService
    {
        private ADODormitory service;

        public DormitoryService(ADODormitory dormService)
        {
            service = dormService;
        }

        public IEnumerable<Dormitory> GetAllDormitories()
        {
            return service.GetAllDormitories();
        }
    }
}
