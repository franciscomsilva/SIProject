using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReadingType
    {
        public int Id { get; set; }
        public string MeasureName { get; set; }
        public string MeasureType { get; set; }
        public int SensorId { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string Timestamp { get; set; }
    }
}
