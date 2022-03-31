using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();

        IEnumerable<Student> WaitingList();

        Student GetStudentByStudentNo(int studentNo);
    }
}
