using GlobalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlobalAPI.Controllers
{
    public class DefaultController : ApiController
    {
        public IHttpActionResult GetApiStatus()
        {
            ApiStatus status = new ApiStatus()
            {
                Version = "1.0.0"
            };

            return Ok(status);
        }
    }
}
