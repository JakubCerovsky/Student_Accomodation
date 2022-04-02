using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;

namespace StudentAccomodation.Pages.Students
{
    public class GetLeasingsModel : PageModel
    {
        private IStudentService studentService;
        private ILeasingService leasingService;
        private IRoomService roomService;
        [BindProperty]
        public Student Student { get; set; }
        public Leasing Leasing { get; set; }
        public Room Room { get; set; }

        public GetLeasingsModel(IStudentService sService, ILeasingService lService, IRoomService rService)
        {
            studentService = sService;
            leasingService = lService;
            roomService = rService;
        }
        public void OnGet(int studentNo)
        {
            Student = studentService.GetStudentByStudentNo(studentNo);
            Leasing = leasingService.GetLeasingByStudentNo(studentNo);
            Room = roomService.GetRoomByPlaceNo(Leasing.PlaceNo);
        }
    }
}
