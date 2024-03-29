﻿using StudentAccomodation.Models;
using StudentAccomodation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.StudentService
{
    public class StudentService:IStudentService
    {
        private ADOStudent service;

        public StudentService(ADOStudent studentService)
        {
            service = studentService;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return service.GetAllStudents();
        }

        public IEnumerable<Student> WaitingList()
        {
            return service.WaitingList();
        }

        public Student GetStudentByStudentNo(int studentNo)
        {
            return service.GetStudentByStudentNo(studentNo);
        }

        public void DeleteStudent(Student student)
        {
            service.DeleteStudent(student);
        }
    }
}
