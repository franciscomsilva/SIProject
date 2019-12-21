using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GlobalAPI.Models
{
    public class SensorData
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "sensor_id")]
        public int SensorId { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public int LocationId { get; set; }

        [JsonProperty(PropertyName = "field_id")]
        public int FieldId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "valid")]
        public bool Valid { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Timestamp { get; set; }

        public void Insert()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO t_sensor_data (location_id, id_reading, data_value, valid, timestamp) output INSERTED.ID VALUES (@location_id, @id_reading, @data_value, 1, @timestamp)", conn))
                {
                    this.Timestamp = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

                    cmd.Parameters.AddWithValue("@location_id", this.LocationId);
                    cmd.Parameters.AddWithValue("@id_reading", this.FieldId);
                    cmd.Parameters.AddWithValue("@data_value", this.Value);
                    cmd.Parameters.AddWithValue("@timestamp", this.Timestamp);

                    this.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Invalidate()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE t_sensor_data SET valid = 0 WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static SensorData GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT data.id, data.location_id, data.id_reading, data.data_value, data.valid, data.timestamp, reading.sensor_id FROM t_sensor_data data, t_sensor_reading_types reading WHERE data.id_reading = reading.id AND data.id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read()) return null;

                    return SensorData.FromDB(reader);
                }
            }
        }

        public static List<SensorData> GetAllBySensorId(int sensorId, Nullable<DateTime> startDate = null, Nullable<DateTime> endDate = null)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT data.id, data.location_id, data.id_reading, data.data_value, data.valid, data.timestamp, reading.sensor_id FROM t_sensor_data data, t_sensor_reading_types reading WHERE data.id_reading = reading.id AND reading.sensor_id = @sensorId", conn))
                {
                    if (startDate != null)
                    {
                        cmd.CommandText += " AND data.timestamp >= @startDate ";
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                    }

                    if (endDate != null)
                    {
                        cmd.CommandText += " AND data.timestamp <= @endDate ";
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                    }

                    cmd.Parameters.AddWithValue("@sensorId", sensorId);

                    List<SensorData> sensorData = new List<SensorData>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sensorData.Add(SensorData.FromDB(reader));
                    }

                    return sensorData;
                }
            }
        }

        public static List<SensorData> GetLatestBySensorId(int sensorId)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT data.id, data.location_id, data.id_reading, data.data_value, data.valid, data.timestamp, reading.sensor_id FROM t_sensor_data data, t_sensor_reading_types reading WHERE data.id_reading = reading.id AND reading.sensor_id = @sensorId AND valid = 1 AND data.timestamp = (SELECT MAX(timestamp) FROM t_sensor_data WHERE valid = 1 AND id_reading = data.id_reading)", conn))
                {
                    cmd.Parameters.AddWithValue("@sensorId", sensorId);

                    List<SensorData> sensorData = new List<SensorData>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        sensorData.Add(SensorData.FromDB(reader));
                    }

                    return sensorData;
                }
            }
        }

        public static SensorData FromDB(SqlDataReader reader)
        {
            return new SensorData()
            {
                Id = (int)reader["id"],
                SensorId = (int)reader["sensor_id"],
                LocationId = (int)reader["location_id"],
                FieldId = (int)reader["id_reading"],
                Value = reader["data_value"].ToString(),
                Valid = (bool)reader["valid"],
                Timestamp = DateTime.Parse(reader["timestamp"].ToString())
            };
        }
    }
}