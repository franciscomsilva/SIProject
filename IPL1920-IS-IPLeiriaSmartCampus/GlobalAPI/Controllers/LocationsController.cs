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

        // GET: api/Locations/5
        public IHttpActionResult Get(int id)
        {
            Location location = Location.GetById(id);
            if (location == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid location"));

            return Ok(location);
        }
    }
}
