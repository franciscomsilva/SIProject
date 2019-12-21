using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using Models;
using Newtonsoft.Json;

namespace DSA.Controllers
{
    class DataController
    {
        static string connectionString = Properties.Resources.BDConnectString;

        private DataController()
        {
        }
        private static DataController instance = null;
        public static DataController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataController();
                }
                return instance;

            }
        }
        public string BootUpDataShow()
        {
            string values = JsonConvert.SerializeObject(LocationController.Instance.GetAllLocations());
            values += "§" + JsonConvert.SerializeObject(SensorController.Instance.GetAllReadingTypes());
            values += "§" + JsonConvert.SerializeObject(SensorController.Instance.GetAllSensors());
            values += "§" + JsonConvert.SerializeObject(AlertController.Instance.GetAllAlerts());

            return values;
        }
        public void ParseSensorData(int sensor_id, string reading_name, string value,[Optional] string location_name)
        {
            int locationId=-1;
            if (!SensorController.Instance.GetSensor(sensor_id).Personal)
            {
                 locationId = SensorController.Instance.GetSensorLocation(sensor_id);
            }
            else//Sensor É pessoal therefore temos que ver da localização em runtime e meter no reading
            {
                if (location_name==null)
                {
                    Console.WriteLine("Unnable to fetch any form of location!");
                    return;
                }
                else
                {
                    locationId = LocationController.Instance.CheckIfLocationExists(location_name);
                }
            }
            if (locationId == -1)
            {
                Console.WriteLine("Something went wrong and location was unretriavable!");
                return;
            }

            ReadingType readingType = SensorController.Instance.GetReadingType(sensor_id, reading_name);
            if (readingType == null)
            {
                Console.WriteLine("Something went wrong and reading type was unretrievable!");
                return;
            }
            //Ok, ja demos retrieve de MAJOR MAJOR id's, agora siga checkar se temos min, max values, tipo de valores e inserir no fim
            try
            {


                switch (readingType.MeasureType.ToUpper())
                {
                    case "FLOAT":
                        if (!float.TryParse(value, out var finalValue1))
                        {
                            Console.WriteLine("Data Value is invalid for its type, registering as invalid!");
                            insertData(locationId, readingType.Id, value, false);
                            return;
                        }
                        else
                        {
                            if (finalValue1 > float.Parse(readingType.MaxValue) || finalValue1 < float.Parse(readingType.MinValue))
                            {
                                Console.WriteLine("Data Value is not within its set values!");
                                insertData(locationId, readingType.Id, value, false);
                                return;
                            }
                        }
                        break;
                    case "INT":
                        if (!int.TryParse(value, out var finalValue2))
                        {
                            Console.WriteLine("Data Value is invalid for its type, registering as invalid!");
                            insertData(locationId, readingType.Id, value, false);
                            return;
                        }
                        else
                        {
                            if (finalValue2 > int.Parse(readingType.MaxValue) || finalValue2 < int.Parse(readingType.MinValue))
                            {
                                Console.WriteLine("Data Value is not within its set values!");
                                insertData(locationId, readingType.Id, value, false);
                                return;
                            }
                        }
                        break;
                    case "BOOL":
                        if (!bool.TryParse(value, out var finalValue3))
                        {
                            Console.WriteLine("Data Value is invalid for its type, registering as invalid!");
                            insertData(locationId, readingType.Id, value, false);
                            return;
                        }
                        break;
                    case "STRING": var finalValue4 = value; break;
                    default: Console.WriteLine("Uh Oh, Spaghetios!"); break;
                }
                //--------------------------------------------Valores Aceitaveis Agora Vem Inserção na BD------------------------------------------------//
                Console.WriteLine("Data is valid, registering as valid");
                insertData(locationId, readingType.Id, value, true);
                //E agora reenvia-se estes dados para o clean data
                SensorData sensorData = new SensorData()
                {
                    LocationId=locationId,
                    MeasureName=readingType.MeasureName,
                    MeasureType=readingType.MeasureType,
                    SensorId=sensor_id,
                    Value=value
                };
                MQTTHandler.Instance.publishData("clean_data/"+sensor_id,JsonConvert.SerializeObject(sensorData));

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong parsing sensor data! Reason: " + e.Message);
            }


        }
        public void insertData(int location_id, int id_reading, string data_value, bool valid)
        {
            try
            {

                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_sensor_data VALUES(@location_id,@id_reading,@data_value,@valid)", sql);
                sqlCommand.Parameters.AddWithValue("@location_id", location_id);
                sqlCommand.Parameters.AddWithValue("@id_reading", id_reading);
                sqlCommand.Parameters.AddWithValue("@data_value", data_value);
                sqlCommand.Parameters.AddWithValue("@valid", valid);
                sqlCommand.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed inserting new data! Reason:" + e.Message);
                Console.ReadKey();
            }
        }


    }
}
