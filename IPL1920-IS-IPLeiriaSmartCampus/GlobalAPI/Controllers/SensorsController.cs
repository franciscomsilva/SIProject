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
        // TODO https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api
        public IHttpActionResult Get()
        {
            Sensor[] sensors = new Sensor[] {
                new Sensor()
                {
                    Id = 1,
                    UserId = 2,
                    LocationId = null,
                    Description = "DHT",
                    Personal = false,
                    Valid = true,
                    Fields = new SensorField[] {
                        new SensorField()
                        {
                            Name = "temperature",
                            Type = "float",
                            MinValue = "-20",
                            MaxValue = "60"
                        }
                    },
                    Date = DateTime.Now
                }
            };
            return Ok(sensors);
        }

        // GET: api/Sensors/5
        public string Get(int id)
        {
            return "value";
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
