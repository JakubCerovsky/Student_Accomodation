using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Leasings
{
    public class GetLeasingsModel : PageModel
    {
        private ILeasingService leasingService;

        public IEnumerable<Leasing> leasings { get; set; }

        public GetLeasingsModel(ILeasingService service)
        {
            leasingService = service;
        }
        public void OnGet()
        {
            leasings = leasingService.GetAllLeasings();
        }
    }
}
