using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalAPI.Models
{
    public class ApiStatus
    {
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}