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
    }
}
