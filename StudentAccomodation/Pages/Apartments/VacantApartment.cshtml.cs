using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Apartments
{
    public class VacantApartmentModel : PageModel
    {
        private IApartmentService _appartService;
        private IRoomService _roomService;
        [BindProperty] public Leasing Leasing { get; set; }
        public IEnumerable<Room> rooms { get; set; }

        public VacantApartmentModel(IApartmentService appartService, IRoomService roomService)
        {
            _appartService = appartService;
            _roomService = roomService;
        }
        public void OnGet(int apartNo)
        {
            rooms = _appartService.GetVacantRoomsApartment(apartNo);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Leasing.PlaceNo = Convert.ToInt32(Request.Form["placeNo"]);

            _roomService.AddLeasing(Leasing);
            return RedirectToPage("/Leasings/GetLeasings");
        }
    }
}
