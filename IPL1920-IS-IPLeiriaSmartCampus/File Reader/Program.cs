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
        static void Main(string[] args)
        {
            byte[] data = File.ReadAllBytes("bin_1");

            for (int i = 0; i < data.Length; i += 24)
            {
                // Id
                byte[] idData = new byte[1];
                Array.Copy(data, i + 0, idData, 0, 1);
                byte id = idData[0];

                Console.WriteLine("Id (Raw): " + BitConverter.ToString(idData));
                Console.WriteLine("Id: " + id);

                // Temperature
                byte[] temperatureData = new byte[4];
                Array.Copy(data, i + 4, temperatureData, 0, 4);
                Single temperature = BitConverter.ToSingle(temperatureData, 0);

                Console.WriteLine("Temperature (Raw): " + BitConverter.ToString(temperatureData));
                Console.WriteLine("Temperature: " + temperature);

                // Humidity
                byte[] humidityData = new byte[4];
                Array.Copy(data, i + 8, humidityData, 0, 4);
                Single humidity = BitConverter.ToSingle(humidityData, 0);

                Console.WriteLine("Humidity (Raw): " + BitConverter.ToString(humidityData));
                Console.WriteLine("Humidity: " + humidity);

                // Battery
                byte[] batteryData = new byte[1];
                Array.Copy(data, i + 12, batteryData, 0, 1);
                byte battery = batteryData[0];

                Console.WriteLine("Battery (Raw): " + BitConverter.ToString(batteryData));
                Console.WriteLine("Battery: " + battery);

                // Timestamp
                byte[] timestampData = new byte[4];
                Array.Copy(data, i + 16, timestampData, 0, 4);
                UInt32 timestamp = BitConverter.ToUInt32(timestampData, 0);

                Console.WriteLine("Timestamp (Raw): " + BitConverter.ToString(timestampData));
                Console.WriteLine("Timestamp: " + timestamp);
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
