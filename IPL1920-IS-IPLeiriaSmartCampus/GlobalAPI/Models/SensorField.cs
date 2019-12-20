using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GlobalAPI.Models
{
    public class SensorField
    {
        public static List<string> ValidTypes { get { return new List<string>() { "float", "int", "string", "bool" }; } }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "min_value")]
        public string MinValue { get; set; }

        [JsonProperty(PropertyName = "max_value")]
        public string MaxValue { get; set; }

        public void Insert(Sensor sensor)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO t_sensor_reading_types (measure_name, measure_type, sensor_id, timestamp, min_value, max_value) VALUES (@measure_name, @measure_type, @sensor_id, @timestamp, @min_value, @max_value)", conn))
                {
                    cmd.Parameters.AddWithValue("@measure_name", this.Name);
                    cmd.Parameters.AddWithValue("@measure_type", this.Type);
                    cmd.Parameters.AddWithValue("@sensor_id", sensor.Id);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@min_value", this.MinValue);
                    cmd.Parameters.AddWithValue("@max_value", this.MaxValue);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static List<SensorField> GetAllForSensor(int sensorId)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT measure_name, measure_type, min_value, max_value FROM t_sensor_reading_types WHERE sensor_id = @sensorId", conn))
                {
                    cmd.Parameters.AddWithValue("sensorId", sensorId);
                    List<SensorField> sensorFields = new List<SensorField>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sensorFields.Add(new SensorField()
                        {
                            Name = reader["measure_name"].ToString(),
                            Type = reader["measure_type"].ToString(),
                            MinValue = reader["min_value"].ToString(),
                            MaxValue = reader["max_value"].ToString()
                        });
                    }

                    return sensorFields;
                }
            }
        }
    }
}