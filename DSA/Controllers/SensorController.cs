using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;

namespace DSA.Controllers
{
    class SensorController
    {
        static string connectionString = Properties.Resources.BDConnectString;

        private  SensorController()
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
                        Id=(int)reader["id"],
                        UserID=(int)reader["user_id"],
                        Personal = (bool)reader["personal"],
                        Valid=(bool)reader["valid"],
                        CreatedAt=(string)reader["date"]
                    };
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error fetching sensor with id " + index + " Reason:" + e.Message);
            }
            

            return sensor;
        }
        public int GetSensorLocation(int sensor_id)
        {
            int location_id=-1;
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_sensors WHERE id=@id", sql);
                command.Parameters.AddWithValue("@id",sensor_id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    location_id = (int)reader["location_id"];
                };

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching sensor with id " + sensor_id + " Reason:" + e.Message);
            }

            return location_id;

        }
        public void AddSensor(int location_id)
        {
            //Notas:Todos os sensores freshly created são validos, e sensores registados na DSA NÃO são pessoais
            //Assume-se que o sensor é criado a partir do momento em que se chama a função therefore o timestamp e atribuido agora
            try
            {
                Console.WriteLine(LoginController.Instance.LoggedId);
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_sensors VALUES(@user_id,0,1,@date_creation,@location_id)", sql);
                sqlCommand.Parameters.AddWithValue("@user_id",LoginController.Instance.LoggedId);
               sqlCommand.Parameters.AddWithValue("@location_id", location_id);
                sqlCommand.Parameters.AddWithValue("@date_creation",DateTime.Now.ToShortDateString());
                sqlCommand.ExecuteNonQuery();

                sql.Close();
                Console.WriteLine("Sensor created successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed creating a new sensor! Reason:" + e.Message);
                Console.ReadKey();
            }
        }
        public List<string> getAllReadingTypes()
        {
            List<string> readingTypes = new List<string>();
            
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT measure_name FROM t_sensor_reading_types", sql);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    readingTypes.Add((string)reader["measure_name"]);
                };
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed retrieving sensor list! Reason:" + e.Message);
                Console.ReadKey();
                return null;
            }



            return readingTypes;
        }
        public List<Sensor> GetAllSensors()
        {
            List<Sensor> sensors = new List<Sensor>();
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM t_sensors", sql);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Sensor sensor = new Sensor
                    {
                        Id = (int)reader["id"],
                        UserID = (int)reader["user_id"],
                        Personal =(bool)reader["personal"],
                        Valid = (bool)reader["valid"],
                        CreatedAt=(string)reader["date"] 

                    };
                    sensors.Add(sensor);
                };
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed retrieving sensor list! Reason:" + e.Message);
                Console.ReadKey();
                return null;
            }


            return sensors;
        }
        public List<string> GetSensorReadingTypes(int index )
        {
            List<string> sensorsReadings = new List<string>();

            
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_sensor_reading_types WHERE sensor_id=@id", sql);
                command.Parameters.AddWithValue("@id", index);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sensorsReadings.Add((string)reader["measure_name"]);   
                };

            }
            catch (Exception e)
            { 
                Console.WriteLine("Error fetching sensor types  with id " + index + " Reason:" + e.Message);
            }


            return sensorsReadings;
        }
        public string GetReadingType(int index)
        {
            string measure_type="";
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_sensor_reading_types WHERE id=@id ", sql);
                command.Parameters.AddWithValue("@id", index);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    measure_type = (string)reader["measure_name"];
                };

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching reading type!" + " Reason:" + e.Message);
            }

            return measure_type;

        }
        public void insertSensorData(int sensor_id,string reading_name,string value )
        {
            int locationId = GetSensorLocation(sensor_id);
            if (locationId==-1)
            {
                Console.WriteLine("Something went wrong and location was unretriavable!");
                return;
            }
            int reading_id = -1;
            reading_id = GetReadingTypeId(sensor_id,reading_name);
            if (reading_id==-1)
            {
                Console.WriteLine("Something went wrong and reading id was unreatriavable!");
                return;
            }
           


        }
        public int GetReadingTypeId(int sensor_id, string name)
        {
            int id=-1;
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_sensor_reading_types WHERE sensor_id=@id AND measure_name=@name", sql);
                command.Parameters.AddWithValue("@id", sensor_id);
                command.Parameters.AddWithValue("@name",name);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader["id"];
                };

            }
            catch (Exception e)
            {
                Console.WriteLine("Error fetching reading type!" + " Reason:" + e.Message);
            }
            return id;

        }
        public void addReadingType(string measure_name,string measure_type, int sensor_id, [Optional] string min_value, [Optional] string max_value)
        {

            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
             
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_sensor_reading_types VALUES(@measure_name,@measure_type,@sensor_id,@timestamp,@min_value,@max_value)", sql);
                sqlCommand.Parameters.AddWithValue("@measure_name",measure_name);
                sqlCommand.Parameters.AddWithValue("@measure_type",measure_type);
                sqlCommand.Parameters.AddWithValue("@sensor_id",sensor_id);
                sqlCommand.Parameters.AddWithValue("@timestamp",DateTime.Now);
                if (min_value != null)
                {
                    sqlCommand.Parameters.AddWithValue("@min_value", min_value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@min_value", DBNull.Value);
                }
                if (max_value != null)
                {
                    sqlCommand.Parameters.AddWithValue("@max_value", max_value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@max_value", DBNull.Value);

                }
                SqlDataReader reader = sqlCommand.ExecuteReader();
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed retrieving sensor list! Reason:" + e.Message);
                Console.ReadKey();
                return;
            }
        }
    }
}
