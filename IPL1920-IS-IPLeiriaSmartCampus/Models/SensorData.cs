using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SensorData
    {
        public int SensorId { get; set; }
        public int LocationId { get; set; }
        public string MeasureName { get; set; }
        public string MeasureType { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
    }
}
