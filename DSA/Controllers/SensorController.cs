using DSA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DSA.Controllers
{
    class SensorController
    {
        static string connectionString = Properties.Resources.BDConnectString;

        SensorController()
        {
        }
        private static SensorController instance = null;
        public static SensorController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SensorController();
                }
                return instance;
            }
        }
        public Sensor GetSensor(int index)
        {

          Sensor sensor = null;
            if (index <= 0)
            {
                Console.WriteLine("Index needs to be positive!");
                return sensor;
            }
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_sensors WHERE id=@id", sql);
                command.Parameters.AddWithValue("@id", index);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    sensor = new Sensor
                    {
                        id=(int)reader["id"],
                        user_id=(int)reader["user_id"],
                        location_id=(int)reader["location_id"],
                        personal=(bool)reader["personal"],
                        valid=(bool)reader["valid"],
                        date_creation=(string)reader["date"]
                    };
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error fetching sensor with id " + index + " Reason:" + e.Message);
            }
            

            return sensor;
        }
        public void AddSensor(int location_id)
        {
            //Notas:Todos os sensores freshly created são validos
            //Assume-se que o sensor é criado a partir do momento em que se chama a função therefore o timestamp e atribuido agora
            //TODO:lock c/ login(admin)
            //TODO receber dinamicamente de user loggado o id dele
            throw new NotImplementedException();
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_sensors VALUES(@user_id,@location_id,0,1,@date_creation)", sql);
               sqlCommand.Parameters.AddWithValue("@location_id", location_id);
                sqlCommand.Parameters.AddWithValue("@date_creation",DateTime.Now.ToShortDateString());
                sqlCommand.ExecuteNonQuery();

                sql.Close();
                Console.WriteLine("Location created successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed creating a new location! Reason:" + e.Message);
                Console.ReadKey();
            }
        }
    }
}
