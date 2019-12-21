using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BinaryBatSensorData : SensorData
    {
        public float Temperature { get; set; }
        public DateTime TemperatureTimestamp { get; set; }
        public float Humidity { get; set; }
        public DateTime HumidityTimestamp { get; set; }
        public int Battery { get; set; }
        public DateTime BatteryTimestamp { get; set; }
    }
}