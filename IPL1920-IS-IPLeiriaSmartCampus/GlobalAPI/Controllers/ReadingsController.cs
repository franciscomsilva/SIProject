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
    public class ReadingsController : ApiController
    {
        // POST: api/Readings
        public IHttpActionResult Post([FromBody]SensorData reading)
        {
            Sensor sensor;
            Location readingLocation;
            SensorField field;
            if (reading == null || (sensor = Sensor.GetById(reading.SensorId)) == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid sensor"));
            if (sensor.LocationId == null && (readingLocation = Location.GetById(reading.LocationId)) == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid location"));
            if ((field = SensorField.GetById(reading.FieldId)) == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field"));
            if (sensor.Id != field.SensorId) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid field and sensor; the sensor doesn't have the specified field"));
            if (reading.Value == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Value is required"));

            switch (field.Type)
            {
                case "float":
                    float valueF;
                    if (!float.TryParse(reading.Value, out valueF)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid value; the provided value can't be casted to the correct type"));
                    reading.Value = valueF.ToString();

                    if (field.MinValue != null && valueF < float.Parse(field.MinValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid value; the provided value is not in the field range"));
                    if (field.MaxValue != null && valueF > float.Parse(field.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid value; the provided value is not in the field range"));

                    break;
                case "int":
                    int valueI;
                    if (!int.TryParse(reading.Value, out valueI)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid value; the provided value can't be casted to the correct type"));
                    reading.Value = valueI.ToString();

                    if (field.MinValue != null && valueI < int.Parse(field.MinValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid value; the provided value is not in the field range"));
                    if (field.MaxValue != null && valueI > int.Parse(field.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid value; the provided value is not in the field range"));

                    break;
                case "bool":
                    bool valueB;
                    if (!bool.TryParse(reading.Value, out valueB)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid value; the provided value can't be casted to the correct type"));
                    reading.Value = valueB.ToString();
                    break;
            }

            reading.Insert();

            return Ok(reading);
        }

        // DELETE: api/Readings/5
        public IHttpActionResult Delete(int id)
        {
            SensorData reading = SensorData.GetById(id);
            if (reading == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid reading"));

            reading.Invalidate();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
