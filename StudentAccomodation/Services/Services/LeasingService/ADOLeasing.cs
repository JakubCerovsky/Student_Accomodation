using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.LeasingService
{
    public class ADOLeasing
    {
        private string connectionString;  
        public IConfiguration Configuration { get; }
        public ADOLeasing(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Leasing> GetAllLeasings()
        {
            List<Leasing> returnList = new List<Leasing>();
            string query = "select * from Leasing";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Leasing leasing = new Leasing();
                        leasing.LeasingNo = Convert.ToInt32(reader["Leasing_No"]);
                        leasing.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                        leasing.DateTo = Convert.ToDateTime(reader["Date_To"]);
                        leasing.StudentNo = Convert.ToInt32(reader["Student_No"]);
                        leasing.PlaceNo = Convert.ToInt32(reader["Place_No"]);

                        returnList.Add(leasing);
                    }
                }
                return returnList;
            }
        }

        public void AddLeasing(Leasing leasing)
        {
            Student student = new Student();
            string queryStudents = "select * from Student where Has_Room = 0 order by Registration_Date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryStudents, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    student.StudentNo = Convert.ToInt32(reader["Student_No"]);
                    student.SName = Convert.ToString(reader["SName"]);
                    student.SAddress = Convert.ToString(reader["SAddress"]);
                    student.HasRent = Convert.ToBoolean(reader["Has_Room"]);
                    student.RegistrationDate = Convert.ToDateTime(reader["Registration_Date"]);
                }
                connection.Close();
            }


            string query = $"Insert into Leasing (Student_No, Place_No, Date_From, Date_To) Values({student.StudentNo}, {leasing.PlaceNo},'20220701 00:00:00 AM' ,'20221231 00:00:00 AM'); " +
                $"UPDATE Student SET Has_Room = 1 WHERE Student_No = {student.StudentNo}; " +
                $"UPDATE Room SET Occupied = 1 WHERE Place_No = {leasing.PlaceNo};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int numberOfRowsAffected = command.ExecuteNonQuery();
                }
            }
        }


    }
}
