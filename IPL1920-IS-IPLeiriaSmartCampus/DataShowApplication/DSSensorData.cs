using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataShowApplication
{
    class DSSensorData<T> where T : SensorData
    {
        public Sensor Sensor;
    }
}
