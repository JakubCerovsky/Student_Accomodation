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
        public IConfiguration Configuration { get; }
        public ADORoom(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> returnList = new List<Room>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
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
    }
}
