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
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
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

            string query = $"Insert into Leasing Values('{leasing.LeasingNo}', '{leasing.DateFrom}, '{leasing.DateTo}, '{leasing.PlaceNo}, '{leasing.StudentNo}')";

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
