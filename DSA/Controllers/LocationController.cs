using DSA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;

namespace DSA.Controllers
{
    class LocationController
    {
        static string connectionString = Properties.Resources.BDConnectString;

        public Location GetLocation(int index)
        {

            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM t_locations WHERE @id=id", sql);
                sqlCommand.Parameters.AddWithValue("@id", index);
                SqlDataReader reader = sqlCommand.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }
        public List<Location> GetAllLocations()

        {
             List<Location> locations = new List<Location>();
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM t_locations", sql);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Location location = new Location
                    {
                        id = (int)reader["id"],
                        location_name = (string)reader["location_name"]
                    };
                    locations.Add(location);
                };
                sql.Close();
                
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed retrieving locations list! Reason: "+ e.Message);
                Console.ReadKey();
            }

            return locations;
        }
        public void AddLocation(string name)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_locations VALUES(@name)", sql);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.ExecuteNonQuery();

                sql.Close();
                Console.WriteLine("Location created successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed creating a new location! Reason:" + e.Message);
                Console.ReadKey();
            }
        }
    }
}
