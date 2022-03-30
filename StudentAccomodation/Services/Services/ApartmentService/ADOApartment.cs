using Microsoft.Extensions.Configuration;
using StudentAccomodation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAccomodation.Services.Services.ApartmentService
{
    public class ADOApartment
    {
        private string connectionString;
        public IConfiguration Configuration { get; }
        public ADOApartment(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Apartment> GetAllApartments()
        {
            List<Apartment> returnList = new List<Apartment>();
            string query = "select *  from Appartment";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartment apartments = new Apartment();
                        apartments.ApartmentNo = Convert.ToInt32(reader["Appart_No"]);
                        apartments.Address = Convert.ToString(reader["Address"]);
                        apartments.Types = Convert.ToString(reader["Types"]);
                        returnList.Add(apartments);
                    }
                }
                return returnList;
            }
        }

        public List<Room> GetVacantRoomsApartment(int apartment)
        {
            List<Room> returnList = new List<Room>();
            string query = $"select * from Room WHERE Occupied = 0 and Appart_No = {apartment}";

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
                        room.ApartmentNo = Convert.ToInt32(reader["Appart_No"]);
                        returnList.Add(room);
                    }
                }
                return returnList;
            }
        }
    }
}
