using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace GlobalAPI.Models
{
    public class ApiError
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        public ApiError(string error)
        {
            this.Error = error;
        }
    }
}