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

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}