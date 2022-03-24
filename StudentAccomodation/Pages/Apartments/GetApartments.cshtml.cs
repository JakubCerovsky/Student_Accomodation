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
    public class GetApartmentsModel : PageModel
    {
        private IApartmentService apartService;

        public IEnumerable<Apartment> apartments { get; set; }

        public GetApartmentsModel(IApartmentService service)
        {
            apartService = service;
        }
        public void OnGet()
        {
            apartments = apartService.GetAllApartments();
        }
    }
}
