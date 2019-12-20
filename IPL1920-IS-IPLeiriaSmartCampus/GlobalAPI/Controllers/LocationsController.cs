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

        // POST: api/Locations
        public IHttpActionResult Post([FromBody]Location location)
        {
            if (location == null || location.Name == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Name is required"));
            if (location.Name.Length > 255) return this.Content(HttpStatusCode.BadRequest, new ApiError("Name too long; must be less than 255 characters"));
            if (location.GpsCoords == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("GPS coordinates are required"));
            if (Location.GetByName(location.Name) != null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Duplicate name; must be unique"));

            location.Insert();

            return Ok(location);
        }
    }
}
