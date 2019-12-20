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
        public string Date { get; set; }

        public void Insert()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO t_sensor_data (location_id, id_reading, data_value, valid) output INSERTED.ID VALUES (@location_id, @id_reading, @data_value, 1)", conn))
                {
                    // TODO Timestamp
                    this.Date = DateTime.Now.ToString();

                    cmd.Parameters.AddWithValue("@location_id", this.LocationId);
                    cmd.Parameters.AddWithValue("@id_reading", this.FieldId);
                    cmd.Parameters.AddWithValue("@data_value", this.Value);

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
                // TODO Timestamp
                using (SqlCommand cmd = new SqlCommand("SELECT id, location_id, id_reading, data_value, valid FROM t_sensor_data WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read()) return null;

                    return SensorData.FromDB(reader);
                }
            }
        }

        public static SensorData FromDB(SqlDataReader reader)
        {
            return new SensorData()
            {
                Id = (int)reader["id"],
                LocationId = (int)reader["location_id"],
                FieldId = (int)reader["id_reading"],
                Value = reader["data_value"].ToString(),
                Valid = (bool) reader["valid"]
            };
        }
    }
}