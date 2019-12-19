using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HumBatSensorData : SensorData
    {
        public float Humidity { get; set; }
        public DateTime HumidityTimestamp { get; set; }
        public int Battery { get; set; }
        public DateTime BatteryTimestamp { get; set; }
    }
}
