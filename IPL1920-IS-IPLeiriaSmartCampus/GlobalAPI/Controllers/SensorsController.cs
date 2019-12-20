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
        public IHttpActionResult Post([FromBody]Sensor sensor)
        {
            if (sensor.Description != null && sensor.Description.Length > 140) return this.Content(HttpStatusCode.BadRequest, new ApiError("Description too long; must be less than 140 characters"));
            if (sensor.Fields == null || sensor.Fields.Length < 1) return this.Content(HttpStatusCode.BadRequest, new ApiError("No fields were provided"));

            foreach (SensorField sensorField in sensor.Fields)
            {
                if (sensorField.Name == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Field name is required"));
                if (sensorField.Name.Length > 32) return this.Content(HttpStatusCode.BadRequest, new ApiError("Field name too long; must be less than 32 characters"));
                if (sensorField.Type == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Field type is required"));
                if (!SensorField.ValidTypes.Contains(sensorField.Type)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field type; type must be float, int, string or bool"));

                switch (sensorField.Type)
                {
                    case "float":
                        float _minValueF, _maxValueF;
                        Nullable<float> minValueF = null, maxValueF = null;
                        if (sensorField.MinValue != null) minValueF = float.TryParse(sensorField.MinValue, out _minValueF) ? _minValueF : (float?)null;
                        if (sensorField.MaxValue != null) maxValueF = float.TryParse(sensorField.MaxValue, out _maxValueF) ? _maxValueF : (float?)null;

                        if ((minValueF != null && maxValueF != null) && (minValueF == null || maxValueF == null)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field range; max_value and min_value must be the same type as type"));
                        if (minValueF > maxValueF) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field range; min_value must be less than max_value"));
                        if (maxValueF < minValueF) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field range; max_value must be greater than min_value"));
                        break;
                    case "int":
                        int _minValueI, _maxValueI;
                        Nullable<int> minValueI = null, maxValueI = null;
                        if (sensorField.MinValue != null) minValueI = int.TryParse(sensorField.MinValue, out _minValueI) ? _minValueI : (int?)null;
                        if (sensorField.MaxValue != null) maxValueI = int.TryParse(sensorField.MaxValue, out _maxValueI) ? _maxValueI : (int?)null;

                        if ((minValueI != null && maxValueI != null) && (minValueI == null || maxValueI == null)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field range; max_value and min_value must be the same type as type"));
                        if (minValueI > maxValueI) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field range; min_value must be less than max_value"));
                        if (maxValueI < minValueI) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field range; max_value must be greater than min_value"));
                        break;
                    case "string":
                    case "bool":
                        return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field range; this field type doesn't support min_value and max_value"));
                }
            }

            if (sensor.LocationId == null || Location.GetById(sensor.LocationId.Value) == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid location"));

            AuthUser user = (AuthUser)Request.Properties["user"];
            sensor.UserId = user.Id;

            sensor.Insert();
            foreach (SensorField sensorField in sensor.Fields)
            {
                sensorField.Insert(sensor);
            }

            return Ok(sensor);
        }

        // TODO
        // DELETE: api/Sensors/5
        public void Delete(int id)
        {
        }
    }
}
