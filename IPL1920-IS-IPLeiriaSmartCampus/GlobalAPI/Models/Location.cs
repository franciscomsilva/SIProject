using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GlobalAPI.Models
{
    public class Location
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "gps_coords")]
        public string GpsCoords { get; set; }

        public void Insert()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO t_locations (location_name, gps_coords) output INSERTED.ID VALUES (@location_name, @gps_coords)", conn))
                {
                    cmd.Parameters.AddWithValue("@location_name", this.Name);
                    cmd.Parameters.AddWithValue("@gps_coords", this.GpsCoords);

                    this.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<Location> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, location_name, gps_coords FROM t_locations", conn))
                {
                    List<Location> locations = new List<Location>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        locations.Add(Location.FromDB(reader));
                    }

                    return locations;
                }
            }
        }

        public static Location GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, location_name, gps_coords FROM t_locations WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read()) return null;

                    return Location.FromDB(reader);
                }
            }
        }
        public static Location GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, location_name, gps_coords FROM t_locations WHERE location_name = @name", conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read()) return null;

                    return Location.FromDB(reader);
                }
            }
        }

        public static Location FromDB(SqlDataReader reader)
        {
            string gps_coords = reader["gps_coords"].ToString();

            return new Location()
            {
                Id = (int)reader["id"],
                Name = reader["location_name"].ToString(),
                GpsCoords = gps_coords.Equals("") ? null : gps_coords
            };
        }
    }
}