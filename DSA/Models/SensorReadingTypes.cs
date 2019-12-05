using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Models
{
    class SensorReadingTypes
    {
        int id { get; set; }
        string measure_name { get; set; }
        string measure_type { get; set; }
        int sensor_id { get; set; }
        string min_value { get; set; }
        string max_value { get; set; }
        string timestamp { get; set; }
    }
}
