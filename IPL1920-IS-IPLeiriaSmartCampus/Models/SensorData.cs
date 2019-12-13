using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SensorData
    {
        public int sensor_id { get; set; }
        public int location_id { get; set; }
        public string measure_name { get; set; }
        public string measure_type { get; set; }
        public string value { get; set; }
    }
}
