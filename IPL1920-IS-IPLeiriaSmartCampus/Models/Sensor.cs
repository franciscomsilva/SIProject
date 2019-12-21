using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

     public class Sensor
        {
            public int Id { get; set; }
            public int UserID { get; set; }
            public int LocationID { get; set; }
            public bool Personal { get; set; }
            public bool Valid { get; set; }
            public string CreatedAt { get; set; }


        }
    
}
