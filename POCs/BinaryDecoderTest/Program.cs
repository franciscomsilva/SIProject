using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDecoderTest
{
    class Program
    {

        //-- 1
        //1 | 22.03 | 47.09 | 100 | 1574070951
        //2 | 22.26 | 47.46 | 99 | 1574070951

        //id | ?        | temp        | humidity    | B  | ?        | timestamp?  | ?
        //01 | 85 A8 43 | 71 3D B0 41 | 29 5C 3C 42 | 64 | 55 00 00 | A7 6A D2 5D | 00 00 00 00
        //02 | 85 A8 43 | 7B 14 B2 41 | 0A D7 3D 42 | 63 | 55 00 00 | A7 6A D2 5D | 00 00 00 00

        //-- 2
        //1 | 22.79 | 47.13 | 100 | 1574071617
        //2 | 22.28 | 47.93 | 99 | 1574071617

        //id | ?        | temp        | humidity    | B  | ?        | timestamp?  | ?
        //01 | C5 D6 11 | 52 B8 B6 41 | AE 47 3C 42 | 64 | 56 00 00 | 3F 6A D2 5D | 00 00 00 00 
        //02 | C5 D6 11 | 9A 99 B5 41 | B8 1E 3E 42 | 63 | 56 00 00 | 3F 6A D2 5D | 00 00 00 00

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
