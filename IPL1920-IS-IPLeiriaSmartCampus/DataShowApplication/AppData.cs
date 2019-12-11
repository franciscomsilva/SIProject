using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataShowApplication
{
    class AppData
    {
        private Dictionary<int, Sensor> Sensors = new Dictionary<int, Sensor>();
        private Dictionary<int, Location> Locations = new Dictionary<int, Location>();
        private Dictionary<int, Alert> Alerts = new Dictionary<int, Alert>();
        private Dictionary<int, Dictionary<string, List<float>>> ValuesByLocation = new Dictionary<int, Dictionary<string, List<float>>>();

        public static AppData Instance = new AppData();

        #region Add Methods
        public void AddSensor(Sensor sensor)
        {
            Sensors.Add(sensor.Id, sensor);
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location.Id, location);
        }

        public void AddAlert(Alert alert)
        {
            Alerts.Add(alert.Id, alert);
        }
        #endregion

        #region Get Methods
        public Dictionary<int, Sensor> GetAllSensors()
        {
            return Sensors;
        }

        public Dictionary<int, Location> GetAllLocations()
        {
            return Locations;
        }

        public Dictionary<int, Alert> GetAllAlerts()
        {
            return Alerts;
        }

        public Dictionary<int, Dictionary<string, List<float>>> GetAllValuesByLocation()
        {
            return ValuesByLocation;
        }
        public Dictionary<string, List<float>> GetValuesByLocationId(int id)
        {
            return ValuesByLocation[id];
        }
        #endregion

        #region Find Methods
        public Sensor FindSensorById(int id)
        {
            return Sensors[id];
        }

        public Location FindLocationById(int id)
        {
            return Locations[id];
        }

        public Alert FindAlertById(int id)
        {
            return Alerts[id];
        }

        public List<Sensor> FindSensorsByLocation(int id)
        {
            List<Sensor> sensors = new List<Sensor>();

            foreach (Sensor sensor in Sensors.Values)
            {
                if (sensor.LocationID == id) sensors.Add(sensor);
            }
            return sensors;
        }
        #endregion

        public void SaveSensorValues(SensorData sensor)
        {
            //get all properties of SensorData (reflection)
            foreach (PropertyInfo prop in sensor.GetType().GetProperties())
            {
                //get all properties with timestamp at the end
                bool hasTimestamp = prop.Name.IndexOf("Timestamp") > 0;
                if (hasTimestamp)
                {
                    //get property name without timestamp ex: BatteryTimestamp -> Battery
                    string key = prop.Name.Replace("Timestamp", "");
                    //get value from property
                    float value = float.Parse(sensor.GetType().GetProperty(key).GetValue(sensor).ToString());
                    if (!ValuesByLocation.ContainsKey(sensor.LocationId))
                    {
                        ValuesByLocation.Add(sensor.LocationId, new Dictionary<string, List<float>>());
                    }

                    Dictionary<string, List<float>> locationValues = ValuesByLocation[sensor.LocationId];

                    if (!locationValues.ContainsKey(key))
                    {
                        locationValues.Add(key, new List<float>());
                    }
                    locationValues[key].Add(value);
                }
            }
        }
    }
}
