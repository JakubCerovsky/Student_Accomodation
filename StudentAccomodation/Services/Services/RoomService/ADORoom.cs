using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.RoomService
{
    public class ADORoom
    {
        private string connectionString;
        public IConfiguration Configuration { get; }
        public ADORoom(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Room> GetAllRooms()
        {
            List<Room> returnList = new List<Room>();
            string query = "select *  from Room";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.PlaceNo = Convert.ToInt32(reader["Place_No"]);
                        room.RoomNo = Convert.ToInt32(reader["Room_No"]);
                        room.RentPerSemester = Convert.ToInt32(reader["Rent_Per_Semester"]);
                        room.Occupied = Convert.ToBoolean(reader["Occupied"]);
                        room.ApartmentNo = (reader["Appart_No"] != DBNull.Value) ? Convert.ToInt32(reader["Appart_No"]) : 0;
                        room.DormitoryNo = (reader["Dormitory_No"] != DBNull.Value) ? Convert.ToInt32(reader["Dormitory_No"]) : 0;                        
                        returnList.Add(room);
                    }
                }
                return returnList;
            }
        }

        public List<Room> GetAllVacantRooms()
        {
            List<Room> returnList = new List<Room>();
            string query = "select * from Room WHERE Occupied = 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.PlaceNo = Convert.ToInt32(reader["Place_No"]);
                        room.RoomNo = Convert.ToInt32(reader["Room_No"]);
                        room.RentPerSemester = Convert.ToInt32(reader["Rent_Per_Semester"]);
                        room.Occupied = Convert.ToBoolean(reader["Occupied"]);
                        room.ApartmentNo = (reader["Appart_No"] != DBNull.Value) ? Convert.ToInt32(reader["Appart_No"]) : 0;
                        room.DormitoryNo = (reader["Dormitory_No"] != DBNull.Value) ? Convert.ToInt32(reader["Dormitory_No"]) : 0;
                        returnList.Add(room);
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

            string d = DateTime.Now.ToString("yyyy-MM-dd");


            string query = $"Insert into Leasing (Student_No, Place_No, Date_From, Date_To) Values({leasing.PlaceNo}, {student.StudentNo}, {d}, {d}); " +
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
