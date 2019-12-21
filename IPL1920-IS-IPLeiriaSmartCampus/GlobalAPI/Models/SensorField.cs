using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GlobalAPI.Models
{
    public class SensorField
    {
        public static List<string> ValidTypes { get { return new List<string>() { "float", "int", "string", "bool" }; } }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "sensor_id")]
        public int SensorId { get; set; }

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
                using (SqlCommand cmd = new SqlCommand("INSERT INTO t_sensor_reading_types (measure_name, measure_type, sensor_id, timestamp, min_value, max_value) output INSERTED.ID VALUES (@measure_name, @measure_type, @sensor_id, @timestamp, @min_value, @max_value)", conn))
                {
                    this.SensorId = sensor.Id;

                    cmd.Parameters.AddWithValue("@measure_name", this.Name);
                    cmd.Parameters.AddWithValue("@measure_type", this.Type);
                    cmd.Parameters.AddWithValue("@sensor_id", this.SensorId);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@min_value", this.MinValue);
                    cmd.Parameters.AddWithValue("@max_value", this.MaxValue);

                    this.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<SensorField> GetAllForSensor(int sensorId)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, sensor_id, measure_name, measure_type, min_value, max_value FROM t_sensor_reading_types WHERE sensor_id = @sensorId", conn))
                {
                    cmd.Parameters.AddWithValue("sensorId", sensorId);
                    List<SensorField> sensorFields = new List<SensorField>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sensorFields.Add(SensorField.FromDB(reader));
                    }

                    return sensorFields;
                }
            }
        }

        public static SensorField GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, sensor_id, measure_name, measure_type, min_value, max_value FROM t_sensor_reading_types WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read()) return null;

                    return SensorField.FromDB(reader);
                }
            }
        }

        public static SensorField FromDB(SqlDataReader reader)
        {
            string minValue = reader["min_value"].ToString();
            string maxValue = reader["max_value"].ToString();

            return new SensorField()
            {
                Id = (int)reader["id"],
                SensorId = (int)reader["sensor_id"],
                Name = reader["measure_name"].ToString(),
                Type = reader["measure_type"].ToString(),
                MinValue = minValue.Equals("") ? null : minValue,
                MaxValue = maxValue.Equals("") ? null : maxValue
            };
        }
    }
}