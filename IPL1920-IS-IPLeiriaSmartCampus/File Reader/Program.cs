using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Models;

namespace File_Reader
{
    class Program
    {
        private byte[] idData = new byte[1];

        static void Main(string[] args)
        {
            
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = ".";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "bin";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;



            /*VARIABLES TO STORE RAW SENSOR DATA*/
             byte[] temperatureData = new byte[4];
             byte[] idData = new byte[1];
             byte[] humidityData = new byte[4];
             byte[] batteryData = new byte[1];
             byte[] timestampData = new byte[4];



            /*VARIABLES TO STORE CONVERTED SENSOR DATA*/
             int id = 0, battery = 0;
             float temperature;
             Single humidity;
             UInt32 timestamp;

            Console.WriteLine("***********INICIAL FILE READING***********");

            byte[] data = File.ReadAllBytes("bin");

            for (int i = 0; i < data.Length; i += 24)
            {
                // Id
                idData = new byte[1];
                Array.Copy(data, i + 0, idData, 0, 1);
                id = idData[0];

                Console.WriteLine("Id (Raw): " + BitConverter.ToString(idData));
                Console.WriteLine("Id: " + id);

                // Temperature
                temperatureData = new byte[4];
                Array.Copy(data, i + 4, temperatureData, 0, 4);
                temperature = BitConverter.ToSingle(temperatureData, 0);

                Console.WriteLine("Temperature (Raw): " + BitConverter.ToString(temperatureData));
                Console.WriteLine("Temperature: " + temperature);

                // Humidity
                humidityData = new byte[4];
                Array.Copy(data, i + 8, humidityData, 0, 4);
                humidity = BitConverter.ToSingle(humidityData, 0);

                Console.WriteLine("Humidity (Raw): " + BitConverter.ToString(humidityData));
                Console.WriteLine("Humidity: " + humidity);

                // Battery
                batteryData = new byte[1];
                Array.Copy(data, i + 12, batteryData, 0, 1);
                battery = batteryData[0];

                Console.WriteLine("Battery (Raw): " + BitConverter.ToString(batteryData));
                Console.WriteLine("Battery: " + battery);

                // Timestamp
                timestampData = new byte[4];
                Array.Copy(data, i + 16, timestampData, 0, 4);
                timestamp = BitConverter.ToUInt32(timestampData, 0);

                Console.WriteLine("Timestamp (Raw): " + BitConverter.ToString(timestampData));
                Console.WriteLine("Timestamp: " + timestamp);
                Console.WriteLine();

                id = 4;
                /*SENDS DATA VIA MQTT*/
                Console.WriteLine("SENDING VALUES TO MQTT...");
                sendData(id, humidity, temperature, timestamp, battery);

            }


            Console.WriteLine("Checking for file changes....\n Press any key to exit");
            
            Console.Read();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("FILE CHANGE DETECTED...READING FILE CHANGES");


            /*VARIABLES TO STORE RAW SENSOR DATA*/
            byte[] temperatureData = new byte[4];
            byte[] idData = new byte[1];
            byte[] humidityData = new byte[4];
            byte[] batteryData = new byte[1];
            byte[] timestampData = new byte[4];
            byte[] data;



            /*VARIABLES TO STORE CONVERTED SENSOR DATA*/
            int id = 0, battery = 0, i = 0;
            float temperature;
            float humidity;
            UInt32 timestamp;

            Console.WriteLine("BOAS");
            using (FileStream fs = File.Open("bin", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                // Seek 1024 bytes from the end of the file
                fs.Seek(-24, SeekOrigin.End);
                // read 1024 bytes
                data = new byte[24];
                fs.Read(data, 0, 24);

                // Id
                idData = new byte[1];
                Array.Copy(data, i + 0, idData, 0, 1);
                id = idData[0];

                Console.WriteLine("Id (Raw): " + BitConverter.ToString(idData));
                Console.WriteLine("Id: " + id);

                // Temperature
                temperatureData = new byte[4];
                Array.Copy(data, i + 4, temperatureData, 0, 4);
                temperature = BitConverter.ToSingle(temperatureData, 0);

                Console.WriteLine("Temperature (Raw): " + BitConverter.ToString(temperatureData));
                Console.WriteLine("Temperature: " + temperature);

                // Humidity
                humidityData = new byte[4];
                Array.Copy(data, i + 8, humidityData, 0, 4);
                humidity = BitConverter.ToSingle(humidityData, 0);

                Console.WriteLine("Humidity (Raw): " + BitConverter.ToString(humidityData));
                Console.WriteLine("Humidity: " + humidity);

                // Battery
                batteryData = new byte[1];
                Array.Copy(data, i + 12, batteryData, 0, 1);
                battery = batteryData[0];

                Console.WriteLine("Battery (Raw): " + BitConverter.ToString(batteryData));
                Console.WriteLine("Battery: " + battery);

                // Timestamp
                timestampData = new byte[4];
                Array.Copy(data, i + 16, timestampData, 0, 4);
                timestamp = BitConverter.ToUInt32(timestampData, 0);

                Console.WriteLine("Timestamp (Raw): " + BitConverter.ToString(timestampData));
                Console.WriteLine("Timestamp: " + timestamp);
                Console.WriteLine();

                /*SENDS DATA VIA MQTT*/
                Console.WriteLine("SENDING VALUES TO MQTT...");
                sendData(id, humidity, temperature, timestamp, battery);
            }
        }

        private static void sendData(int id,float humidity,float temperature,UInt32 timestamp,int battery)
        {
            MQTTHandler.Instance.publishData($"sensor_data/{id}/Humidity", humidity.ToString());
            MQTTHandler.Instance.publishData($"sensor_data/{id}/temperature", temperature.ToString());
            MQTTHandler.Instance.publishData($"sensor_data/{id}/timestamp", timestamp.ToString());
            MQTTHandler.Instance.publishData($"sensor_data/{id}/battery", battery.ToString());
        }
    }
}
