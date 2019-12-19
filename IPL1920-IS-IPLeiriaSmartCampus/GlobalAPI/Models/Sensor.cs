﻿using Newtonsoft.Json;
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
        public DateTime Date { get; set; }

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
                        int sensorId = (int)reader["id"];
                        string description = reader["description"].ToString();

                        sensors.Add(new Sensor()
                        {
                            Id = sensorId,
                            UserId = (int)reader["user_id"],
                            LocationId = (int)reader["location_id"],
                            Description = description.Equals("") ? null : description,
                            Personal = (bool)reader["personal"],
                            Valid = (bool)reader["valid"],
                            Fields = SensorField.GetAllForSensor(sensorId).ToArray(),
                            Date = DateTime.Parse((string)reader["date"])
                        });
                    }

                    return sensors;
                }
            }
        }
    }
}