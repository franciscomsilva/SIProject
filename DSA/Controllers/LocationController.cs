
using Models;
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
        LocationController()
        {
        }
        private static LocationController instance = null;
        public static LocationController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocationController();
                }
                return instance;
            }
        }
        public Location GetLocation(string name)
        {
            Location location = null;

            try
            {
               
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM t_locations WHERE @name=location_name", sql);
                sqlCommand.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    location = new Location
                    {
                        id = (int)reader["id"],
                        location_name = (string)reader["location_name"]
                    };
                }
                if (location == null)
                {
                    Console.WriteLine("The location with name = " + name + " appears to not exist");
                }
                return location;
            }
            catch (Exception e)
            {

                Console.WriteLine("Error retrieving location! Reason: " + e.Message);
                Console.ReadKey();
            }
            return location;
        }
        public Location GetLocation(int index)
        {
            Location location = null;
            try
            {
               
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM t_locations WHERE @id=id", sql);
                sqlCommand.Parameters.AddWithValue("@id", index);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    location = new Location
                    {
                        id=(int)reader["id"],
                        location_name = (string)reader["location_name"]
                    };
                }
                if (location==null)
                {
                    Console.WriteLine("The location with id = " + index + " appears to not exist");
                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine("Error retrieving location! Reason: "+e.Message);
                Console.ReadKey();
                
            }
            return location;

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
