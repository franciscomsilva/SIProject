﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TempBatSensorData : SensorData
    {
        public float Temperature { get; set; }
        public int Battery { get; set; }
    }
}
