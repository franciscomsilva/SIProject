using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalAPI.Models
{
    public class Sensor
    {
        public int id;
        public int user_id;
        public Nullable<int> location_id;
        public string description;
        public bool personal;
        public bool valid;
        public SensorField[] fields;
        public DateTime date;
    }
}