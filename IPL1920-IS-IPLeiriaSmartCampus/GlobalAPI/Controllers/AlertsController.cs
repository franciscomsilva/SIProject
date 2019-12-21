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
    public class AlertsController : ApiController
    {
        // GET: api/Alerts
        public IHttpActionResult Get(string startDate = null, string endDate = null)
        {
            DateTime _startDateTime, _endDateTime;
            Nullable<DateTime> startDateTime = null, endDateTime = null;

            if (startDate != null) startDateTime = DateTime.TryParse(startDate, out _startDateTime) ? _startDateTime : (DateTime?)null;
            if (startDate != null && startDateTime == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid start date"));
            if (startDateTime != null && (startDateTime < DateTime.MinValue || startDateTime > DateTime.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid start date"));

            if (endDate != null) endDateTime = DateTime.TryParse(endDate, out _endDateTime) ? _endDateTime : (DateTime?)null;
            if (endDate != null && endDateTime == null) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid end date"));
            if (endDateTime != null && (endDateTime < DateTime.MinValue || endDateTime > DateTime.MaxValue)) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid end date"));

            if ((startDateTime != null && endDateTime != null) && endDateTime < startDateTime) return this.Content(HttpStatusCode.BadRequest, new ApiError("Invalid date range; endDate must be greater than or equal to startDate"));

            return Ok(Alert.GetAll(startDateTime, endDateTime));
        }

        // GET api/Alerts/Sensor/5
        [Route("api/alerts/sensor/{sensorId}/{startDate?}/{endDate?}")]
        public IHttpActionResult GetSensorAlerts(int sensorId, string startDate = null, string endDate = null)
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

            return Ok(Alert.GetAllBySensorId(sensorId, startDateTime, endDateTime));
        }

        // GET api/Alerts/Location/5
        [Route("api/alerts/location/{locationId}/{startDate?}/{endDate?}")]
        public IHttpActionResult GetLocationAlerts(int locationId, string startDate = null, string endDate = null)
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

            return Ok(Alert.GetAllByLocationId(locationId, startDateTime, endDateTime));
        }
    }
}
