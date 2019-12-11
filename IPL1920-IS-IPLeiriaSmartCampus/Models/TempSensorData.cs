using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TempSensorData : SensorData
    {
        public float Temperature { get; set; }
        public DateTime TemperatureTimestamp { get; set; }
    }
}
