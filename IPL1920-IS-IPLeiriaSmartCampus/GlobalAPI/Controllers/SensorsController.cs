using GlobalAPI.Filters;
using GlobalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace GlobalAPI.Controllers
{
    [AuthenticationFilter]
    public class SensorsController : ApiController
    {
        // GET: api/Sensors
        public IHttpActionResult Get()
        {
            return Ok(Sensor.GetAll());
        }

        // GET: api/Sensors/5
        public IHttpActionResult Get(int id)
        {
            Sensor sensor = Sensor.GetById(id);
            if (sensor == null) return NotFound();

            return Ok(sensor);
        }

        // POST: api/Sensors
        public void Post([FromBody]string value)
        {
            // AuthUser user = (AuthUser)Request.Properties["user"];
        }

        // PUT: api/Sensors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sensors/5
        public void Delete(int id)
        {
        }
    }
}
