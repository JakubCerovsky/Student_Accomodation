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
        private IRoomService roomService;

        public IEnumerable<Room> rooms { get; set; }

        public GetVacantRoomsModel(IRoomService service)
        {
            roomService = service;
        }
        public void OnGet()
        {
            rooms = roomService.GetAllVacantRooms();
        }
    }
}
