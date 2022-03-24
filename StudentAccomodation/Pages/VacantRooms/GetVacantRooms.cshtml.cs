using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.VacantRooms
{
    public class GetVacantRoomsModel : PageModel
    {
        private IStudentService rooomService;

        public IEnumerable<Room> rooms { get; set; }

        public GetVacantRoomsModel(IStudentService service)
        {
            rooomService = service;
        }
        public void OnGet()
        {
            rooms = rooomService.GetAllRooms();
        }
    }
