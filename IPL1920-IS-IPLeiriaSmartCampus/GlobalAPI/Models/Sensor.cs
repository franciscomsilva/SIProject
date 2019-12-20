using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GlobalAPI.Models
{
    public class Sensor
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public Nullable<int> LocationId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "personal")]
        public bool Personal { get; set; }

        [JsonProperty(PropertyName = "valid")]
        public bool Valid { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public SensorField[] Fields { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        public void Insert()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO t_sensors (user_id, location_id, description, personal, valid, date) output INSERTED.ID VALUES (@user_id, @location_id, @description, 1, 1, @date)", conn))
                {
                    this.Personal = true;
                    this.Valid = true;
                    this.Date = DateTime.Now.ToShortDateString();

                    cmd.Parameters.AddWithValue("@user_id", this.UserId);
                    cmd.Parameters.AddWithValue("@location_id", this.LocationId);
                    cmd.Parameters.AddWithValue("@description", this.Description);
                    cmd.Parameters.AddWithValue("@date", this.Date);

                    this.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<Sensor> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, user_id, location_id, description, personal, valid, date FROM t_sensors", conn))
                {
                    List<Sensor> sensors = new List<Sensor>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sensors.Add(Sensor.FromDB(reader));
                    }

                    return sensors;
                }
            }
        }

        public static Sensor GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, user_id, location_id, description, personal, valid, date FROM t_sensors WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read()) return null;

                    return Sensor.FromDB(reader);
                }
            }
        }

        public static Sensor FromDB(SqlDataReader reader)
        {
            int sensorId = (int)reader["id"];
            string description = reader["description"].ToString();

            return new Sensor()
            {
                Id = sensorId,
                UserId = (int)reader["user_id"],
                LocationId = (int)reader["location_id"],
                Description = description.Equals("") ? null : description,
                Personal = (bool)reader["personal"],
                Valid = (bool)reader["valid"],
                Fields = SensorField.GetAllForSensor(sensorId).ToArray(),
                Date = reader["date"].ToString()
            };
        }
    }
}