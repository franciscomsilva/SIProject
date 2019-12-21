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

            return Created("/readings/" + reading.Id, reading);
        }

        // DELETE: api/Readings/5
        public IHttpActionResult Delete(int id)
        {
            SensorData reading = SensorData.GetById(id);
            if (reading == null || !reading.Valid) return NotFound();

            reading.Invalidate();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET api/Readings/Sensor/5
        [Route("api/readings/sensor/{sensorId}/{startDate?}/{endDate?}")]
        public IHttpActionResult GetSensorReadings(int sensorId, string startDate = null, string endDate = null)
        {
            Sensor sensor = Sensor.GetById(sensorId);
            if (sensor == null) return NotFound();

            DateTime _startDateTime, _endDateTime;
            Nullable<DateTime> startDateTime = null, endDateTime = null;

            if (startDate != null) startDateTime = DateTime.TryParse(startDate, out _startDateTime) ? _startDateTime : (DateTime?)null;
            if (startDate != null && startDateTime == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid start date"));
            if (startDateTime != null && (startDateTime < DateTime.MinValue || startDateTime > DateTime.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid start date"));

            if (endDate != null) endDateTime = DateTime.TryParse(endDate, out _endDateTime) ? _endDateTime : (DateTime?)null;
            if (endDate != null && endDateTime == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid end date"));
            if (endDateTime != null && (endDateTime < DateTime.MinValue || endDateTime > DateTime.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid end date"));

            if ((startDateTime != null && endDateTime != null) && endDateTime < startDateTime) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid date range; endDate must be greater than or equal to startDate"));

            return Ok(SensorData.GetAllBySensorId(sensorId, startDateTime, endDateTime));
        }

        // GET api/Readings/Sensor/5/latest
        [Route("api/readings/sensor/{sensorId}/latest")]
        public IHttpActionResult GetLatestSensorReadings(int sensorId)
        {
            Sensor sensor = Sensor.GetById(sensorId);
            if (sensor == null) return NotFound();

            return Ok(SensorData.GetLatestBySensorId(sensorId));
        }

        // GET api/Readings/Location/5
        [Route("api/readings/location/{locationId}/{startDate?}/{endDate?}")]
        public IHttpActionResult GetLocationReadings(int locationId, string startDate = null, string endDate = null)
        {
            Location location = Location.GetById(locationId);
            if (location == null) return NotFound();

            DateTime _startDateTime, _endDateTime;
            Nullable<DateTime> startDateTime = null, endDateTime = null;

            if (startDate != null) startDateTime = DateTime.TryParse(startDate, out _startDateTime) ? _startDateTime : (DateTime?)null;
            if (startDate != null && startDateTime == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid start date"));
            if (startDateTime != null && (startDateTime < DateTime.MinValue || startDateTime > DateTime.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid start date"));

            if (endDate != null) endDateTime = DateTime.TryParse(endDate, out _endDateTime) ? _endDateTime : (DateTime?)null;
            if (endDate != null && endDateTime == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid end date"));
            if (endDateTime != null && (endDateTime < DateTime.MinValue || endDateTime > DateTime.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid end date"));

            if ((startDateTime != null && endDateTime != null) && endDateTime < startDateTime) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid date range; endDate must be greater than or equal to startDate"));

            return Ok(SensorData.GetAllByLocationId(locationId, startDateTime, endDateTime));
        }

        // GET api/Readings/Location/5/latest
        [Route("api/readings/location/{locationId}/latest")]
        public IHttpActionResult GetLatestLocationReadings(int locationId)
        {
            Location location = Location.GetById(locationId);
            if (location == null) return NotFound();

            return Ok(SensorData.GetLatestByLocationId(locationId));
        }
    }
}
