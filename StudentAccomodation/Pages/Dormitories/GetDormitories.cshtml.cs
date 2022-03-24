using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Dormitories
{
    public class GetDormitoriesModel : PageModel
    {
        private IDormitoryService dormService;

        public IEnumerable<Dormitory> dormitories { get; set; }

        public GetDormitoriesModel(IDormitoryService service)
        {
            dormService = service;
        }
        public void OnGet()
        {
            dormitories = dormService.GetAllDormitories();
        }
    }
}
