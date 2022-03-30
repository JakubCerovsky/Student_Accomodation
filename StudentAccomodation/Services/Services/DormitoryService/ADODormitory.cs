using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.DormitoryService
{
    public class ADODormitory
    {
        private string connectionString;
        public IConfiguration Configuration { get; }
        public ADODormitory(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString= configuration.GetConnectionString("DefaultConnection");
        }

        public List<Dormitory> GetAllDormitories()
        {
            List<Dormitory> returnList = new List<Dormitory>();
            string query = "select *  from Dormitory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Dormitory dormitory = new Dormitory();
                        dormitory.DormitoryNo = Convert.ToInt32(reader["Dormitory_No"]);
                        dormitory.Name = Convert.ToString(reader["Name"]);
                        dormitory.Address = Convert.ToString(reader["Address"]);
                        returnList.Add(dormitory);
                    }
                }
                return returnList;
            }
        }

        public List<Room> GetVacantRoomsDormitory(int dormitory)
        {
            List<Room> returnList = new List<Room>();
            string query = $"select * from Room WHERE Occupied = 0 and Dormitory_No = {dormitory}";

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
                        returnList.Add(room);
                    }
                }
                return returnList;
            }
        }
    }
}
