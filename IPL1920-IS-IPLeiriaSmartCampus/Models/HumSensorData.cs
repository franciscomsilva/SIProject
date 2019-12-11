using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class HumSensorData : SensorData
    {
        public float Humidity { get; set; }
        public DateTime HumidityTimestamp { get; set; }
    }
}
