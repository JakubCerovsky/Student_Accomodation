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
    public class GetStudentsModel : PageModel
    {
        private IStudentService studentService;

        public IEnumerable<Student> students { get; set; }
        public Student Student { get; set; }

        public GetStudentsModel(IStudentService service)
        {
            studentService = service;
        }
        public void OnGet(int studentNo)
        {
            students = studentService.GetAllStudents();
            Student = studentService.GetStudentByStudentNo(studentNo);
        }
    }
}
