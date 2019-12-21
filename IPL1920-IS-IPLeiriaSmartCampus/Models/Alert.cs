using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Models
{
    public class Alert
    {
        public int Id { get; set; }
        public List<Parameter> Parameters { get; set; }
        public int SensorID { get; set; }

        public string Description { get; set; }
        public int UserID { get; set; }

        public bool Enabled { get; set; }

        public String CreatedAt { get; set; }
    }
}
