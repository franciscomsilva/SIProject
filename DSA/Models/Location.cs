using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Models
{
    class Location
    {
        public int id { get; set; }
        public string location_name { get; set; }

        public Location()
        {

        }
        public Location(string name)
        {
            this.location_name = name;
        }

    }
}
