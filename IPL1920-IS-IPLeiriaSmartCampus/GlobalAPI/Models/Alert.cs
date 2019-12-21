using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GlobalAPI.Models
{
    public class Alert
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "sensor_id")]
        public int SensorId { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public int LocationId { get; set; }

        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        public static List<Alert> GetAll(Nullable<DateTime> startDate = null, Nullable<DateTime> endDate = null)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT alert.id, alert.sensor_id, sensor.location_id, usr.name, alert.description, gen_alert.created_at FROM t_generated_alerts gen_alert, t_alerts alert, t_sensors sensor, t_users usr WHERE gen_alert.id_alert = alert.id AND alert.sensor_id = sensor.id AND alert.user_id = usr.id", conn))
                {
                    if (startDate != null)
                    {
                        cmd.CommandText += " AND gen_alert.created_at >= @startDate ";
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                    }

                    if (endDate != null)
                    {
                        cmd.CommandText += " AND gen_alert.created_at <= @endDate ";
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                    }

                    List<Alert> alerts = new List<Alert>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        alerts.Add(Alert.FromDB(reader));
                    }

                    return alerts;
                }
            }
        }

        public static List<Alert> GetAllBySensorId(int sensorId, Nullable<DateTime> startDate = null, Nullable<DateTime> endDate = null)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT alert.id, alert.sensor_id, sensor.location_id, usr.name, alert.description, gen_alert.created_at FROM t_generated_alerts gen_alert, t_alerts alert, t_sensors sensor, t_users usr WHERE gen_alert.id_alert = alert.id AND alert.sensor_id = sensor.id AND alert.user_id = usr.id AND alert.sensor_id = @sensorId", conn))
                {
                    if (startDate != null)
                    {
                        cmd.CommandText += " AND gen_alert.created_at >= @startDate ";
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                    }

                    if (endDate != null)
                    {
                        cmd.CommandText += " AND gen_alert.created_at <= @endDate ";
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                    }

                    cmd.Parameters.AddWithValue("@sensorId", sensorId);

                    List<Alert> alerts = new List<Alert>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        alerts.Add(Alert.FromDB(reader));
                    }

                    return alerts;
                }
            }
        }

        public static List<Alert> GetAllByLocationId(int locationId, Nullable<DateTime> startDate = null, Nullable<DateTime> endDate = null)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT alert.id, alert.sensor_id, sensor.location_id, usr.name, alert.description, gen_alert.created_at FROM t_generated_alerts gen_alert, t_alerts alert, t_sensors sensor, t_users usr WHERE gen_alert.id_alert = alert.id AND alert.sensor_id = sensor.id AND alert.user_id = usr.id AND sensor.location_id = @locationId", conn))
                {
                    if (startDate != null)
                    {
                        cmd.CommandText += " AND gen_alert.created_at >= @startDate ";
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                    }

                    if (endDate != null)
                    {
                        cmd.CommandText += " AND gen_alert.created_at <= @endDate ";
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                    }

                    cmd.Parameters.AddWithValue("@locationId", locationId);

                    List<Alert> alerts = new List<Alert>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        alerts.Add(Alert.FromDB(reader));
                    }

                    return alerts;
                }
            }
        }

        public static Alert FromDB(SqlDataReader reader)
        {
            return new Alert()
            {
                Id = (int)reader["id"],
                SensorId = (int)reader["sensor_id"],
                LocationId = (int)reader["location_id"],
                UserName = reader["name"].ToString(),
                Description = reader["description"].ToString(),
                Timestamp = DateTime.Parse(reader["created_at"].ToString())
            };
        }
    }
}