using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace DSA.Controllers
{
    class AlertController
    {
        private AlertController()
        {
        }
        private static AlertController instance = null;
        public void SaveGeneratedAlert(GeneratedAlert alert)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_generated_alerts VALUES(@id_alert,@timestamp)", sql);
                sqlCommand.Parameters.AddWithValue("@id_alert", alert.alert_id);
                sqlCommand.Parameters.AddWithValue("@timestamp", alert.timestamp);      
                sqlCommand.ExecuteNonQuery();
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed creating a new generated alert! Reason:" + e.Message);
                Console.ReadKey();
            }
        }
        public void AddAlert(Alert alert)
        {

            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_alerts VALUES(@user_id,@enabled,@description,@created_At,@sensor_id)", sql);
                sqlCommand.Parameters.AddWithValue("@user_id",alert.UserID);
                sqlCommand.Parameters.AddWithValue("@enabled",alert.Enabled);
                sqlCommand.Parameters.AddWithValue("@description",alert.Description);
                sqlCommand.Parameters.AddWithValue("@created_at",alert.CreatedAt);
                sqlCommand.Parameters.AddWithValue("@sensor_id",alert.SensorID);
                sqlCommand.ExecuteNonQuery();

                sql.Close();
                Console.WriteLine("Alert created successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed creating a new alert! Reason:" + e.Message);
                Console.ReadKey();
            }
        }
        public static AlertController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlertController();
                }
                return instance;
            }
        }
        static string connectionString = Properties.Resources.BDConnectString;
        public List<Alert> GetAllAlerts()
        {

            List<Alert> alerts = new List<Alert>();
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM t_alerts", sql);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Alert alert = new Alert
                    {
                        Id=(int)reader["id"],
                        UserID=(int)reader["user_id"],
                        SensorID = (int)reader["sensor_id"],
                        Description=(string)reader["description"],
                        Enabled=(bool)reader["enabled"],
                        CreatedAt=(string)reader["created_at"]

                    };
                    alerts.Add(alert);
                };
          
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed retrieving alert list! Reason:" + e.Message);
                Console.ReadKey();
                return null;
            }


            return alerts;
        }
        public void ToggleAlert(string index)
        {
            int alert_id = int.Parse(index);
                        try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE t_alerts SET enabled= 1 ^ enabled where id=@id", sql);
                sqlCommand.Parameters.AddWithValue("@id",alert_id);
                sqlCommand.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed toggling alert! Reason:" + e.Message);
                Console.ReadKey();
              
            }
           

        }
    }
}
