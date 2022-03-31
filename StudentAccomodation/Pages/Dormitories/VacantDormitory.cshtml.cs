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
    public class VacantDormitoryModel : PageModel
    {
        private IDormitoryService _dormService;
        private ILeasingService _leasingService;
        [BindProperty] public Leasing Leasing { get; set; }
        public IEnumerable<Room> rooms { get; set; }

        public VacantDormitoryModel(IDormitoryService dormService, ILeasingService leasingService)
        {
            _dormService = dormService;
            _leasingService = leasingService;
        }
        public void OnGet(int dormitoryNo)
        {
            rooms = _dormService.GetVacantRoomsDormitory(dormitoryNo);

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Leasing.PlaceNo = Convert.ToInt32(Request.Form["placeNo"]);

            _leasingService.AddLeasing(Leasing);
            return RedirectToPage("/Leasings/GetLeasings");
        }
    }
}
