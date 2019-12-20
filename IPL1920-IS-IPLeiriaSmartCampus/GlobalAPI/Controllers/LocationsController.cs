using GlobalAPI.Filters;
using GlobalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Routing;

namespace GlobalAPI.Controllers
{
    [AuthenticationFilter]
    public class LocationsController : ApiController
    {
        // GET: api/Locations
        public IHttpActionResult Get()
        {
            return Ok(Location.GetAll());
        }
    }
}
