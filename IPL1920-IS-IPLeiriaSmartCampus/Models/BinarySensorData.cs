using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BinarySensorData : SensorData
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
