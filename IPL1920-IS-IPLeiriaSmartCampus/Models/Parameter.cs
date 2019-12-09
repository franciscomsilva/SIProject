using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Parameter
    {
        public string Condition { get; set; }
        public ReadingType ReadingType { get; set; }
        public decimal Value { get; set; }
        public override string ToString()
        {
            return Condition + ReadingType + Value;
        }
    }
}
