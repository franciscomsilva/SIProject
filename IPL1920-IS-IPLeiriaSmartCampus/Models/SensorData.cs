using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SensorData
    {
        public int SensorID { get; set; }
        public int LocationID { get; set; }
        public string MeasureName { get; set; }
        public string MeasureType { get; set; }
        public string Value { get; set; }
    }
}
