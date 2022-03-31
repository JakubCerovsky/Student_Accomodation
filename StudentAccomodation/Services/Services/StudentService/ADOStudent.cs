using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace StudentAccomodation.Services.Services.StudentService
{
    public class ADOStudent
    {
        private string connectionString;
        public IConfiguration Configuration { get; }
        public ADOStudent(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Student> GetAllStudents()
        {
            List<Student> returnList = new List<Student>();
            string query = "select *  from Student";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentNo = Convert.ToInt32(reader["Student_No"]);
                        student.SName = Convert.ToString(reader["SName"]);
                        student.SAddress = Convert.ToString(reader["SAddress"]);
                        student.HasRent = Convert.ToBoolean(reader["Has_Room"]);
                        student.RegistrationDate = Convert.ToDateTime(reader["Registration_Date"]);
                        returnList.Add(student);
                    }
                }
                return returnList;
            }
        }

        public Student GetStudentByStudentNo(int studentNo)
        {
            Student student = new Student();
            string query = $"select * from Student where Student.Student_No = {studentNo}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {                        
                        student.StudentNo = Convert.ToInt32(reader["Student_No"]);
                        student.SName = Convert.ToString(reader["SName"]);
                        student.SAddress = Convert.ToString(reader["SAddress"]);
                        student.HasRent = Convert.ToBoolean(reader["Has_Room"]);
                        student.RegistrationDate = Convert.ToDateTime(reader["Registration_Date"]);
                    }
                }
                return student;
            }
        }

        public List<Student> WaitingList()
        {
            List<Student> returnList = new List<Student>();
            string query = "select * from Student where Has_Room=0 order by Registration_Date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentNo = Convert.ToInt32(reader["Student_No"]);
                        student.SName = Convert.ToString(reader["SName"]);
                        student.SAddress = Convert.ToString(reader["SAddress"]);
                        student.HasRent = Convert.ToBoolean(reader["Has_Room"]);
                        student.RegistrationDate = Convert.ToDateTime(reader["Registration_Date"]);
                        returnList.Add(student);
                    }
                }
                return returnList;
            }
        }

        public void DeleteStudent(Student student)
        {

            if (student.HasRent == true)
            {
                string leasingQuery = $"DELETE from Leasing where Leasing.Student_No={student.StudentNo}" +
                    $"DELETE from Student where Student.Student_No={student.StudentNo}";
                     
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(leasingQuery, connection))
                    {
                        int numberOfRowsAffected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            else
            {
                string query = $"DELETE from Student where Student.Student_No={student.StudentNo}";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int numberOfRowsAffected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

            }
        }
    }
}
