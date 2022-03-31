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
            string text = $"Is not part of any Dormitory";
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

        //public static Room UpdateRoomStatus(Room room)
        //{
        //    return room;
        //}


        
    }
}
