using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataShowApplication
{
    class AppData
    {
        private Dictionary<int, Sensor> Sensors = new Dictionary<int, Sensor>();
        private Dictionary<int, Location> Locations = new Dictionary<int, Location>();
        private Dictionary<int, Alert> Alerts = new Dictionary<int, Alert>();
        private Dictionary<int, Dictionary<string, List<Tuple<DateTime, float>>>> ValuesByLocation = new Dictionary<int, Dictionary<string, List<Tuple<DateTime, float>>>>();
        // wild card (can receive any type --> in this case I want to receive any Info...Sensor)
        private Dictionary<int, SensorView> SensorsControl = new Dictionary<int, SensorView>();
        //save function that will be called after a control is created by the AppData
        private Action<UserControl> OnControlCreated = null;
        private Action<Alert> OnAlertCreated = null;
        private List<ReadingType> ReadingTypes = new List<ReadingType>();

        public static AppData Instance = new AppData();

        #region Add Methods
        public void AddSensor(Sensor sensor)
        {
            Sensors.Add(sensor.Id, sensor);
            CreateSensorsControl(sensor);
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location.Id, location);
        }

        public void AddAlert(Alert alert)
        {
            Alerts.Add(alert.Id, alert);
        }

        public void AddReadingType(ReadingType readingType)
        {
            ReadingTypes.Add(readingType);
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

        public Dictionary<int, Dictionary<string, List<Tuple<DateTime, float>>>> GetAllValuesWithLocation()
        {
            return ValuesByLocation;
        }

        public Dictionary<string, List<Tuple<DateTime, float>>> GetValuesByLocation(int locationId)
        {
            return ValuesByLocation[locationId];
        }

        public string[] GetReadingTypesByLocation(int locationId)
        {
            Dictionary<string, List<Tuple<DateTime, float>>> locationValues = ValuesByLocation[locationId];

            return locationValues.Keys.ToArray<string>();
        }

        public List<Tuple<DateTime, float>> GetReadingsByTypeAndLocation(int locationId, String readingType)
        {
            return ValuesByLocation[locationId][readingType];
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

        public List<ReadingType> FindReadingTypesBySensorId(int sensorId)
        {
            List<ReadingType> readingTypes = new List<ReadingType>();

            foreach (ReadingType readingType in ReadingTypes)
            {
                if (readingType.SensorId == sensorId)
                {
                    readingTypes.Add(readingType);
                }
            }

            return readingTypes;
        }
        #endregion

        #region Set Methods
        public void SetOnControllCreated(Action<UserControl> OnControlCreated)
        {
            this.OnControlCreated = OnControlCreated;
        }

        public void SetOnAlertCreated(Action<Alert> OnAlertCreated)
        {
            this.OnAlertCreated = OnAlertCreated;
        }

        public void SetReadingTypes(List<ReadingType> readingTypes)
        {
            ReadingTypes = new List<ReadingType>();
        }

        public void SetAlerts(List<Alert> alerts)
        {
            foreach (Alert alert in alerts)
            {
                Alerts.Add(alert.Id, alert);
            }
        }

        public void SetSensors(List<Sensor> sensors)
        {
            foreach(Sensor sensor in sensors)
            {
                Sensors.Add(sensor.Id, sensor);
            }
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
                        ValuesByLocation.Add(sensor.LocationId, new Dictionary<string, List<Tuple<DateTime, float>>>());
                    }

                    Dictionary<string, List<Tuple<DateTime, float>>> locationValues = ValuesByLocation[sensor.LocationId];

                    if (!locationValues.ContainsKey(key))
                    {
                        locationValues.Add(key, new List<Tuple<DateTime, float>>());
                    }
                    locationValues[key].Add(new Tuple<DateTime, float>((DateTime)prop.GetValue(sensor), value));
                }
            }
            SensorsControl[sensor.SensorId].Update(sensor);
        }

        private void CreateSensorsControl(Sensor sensor)
        {
            //verificar os reading types
            List<String> typeNames = new List<String>();
            SensorView control = null;

            foreach (ReadingType type in FindReadingTypesBySensorId(sensor.Id))
            {
                typeNames.Add(type.MeasureName.ToLower());
            }

            if (typeNames.Contains("temperature") && typeNames.Contains("humidity") && typeNames.Contains("battery"))
            {
                control = new InfoBinaryBatSensor();
            }
            else if (typeNames.Contains("temperature") && typeNames.Contains("humidity"))
            {
                control = new InfoBinarySensor();
            }
            else if (typeNames.Contains("humidity") && typeNames.Contains("battery"))
            {
                control = new InfoHumBatSensor();
            }
            else if (typeNames.Contains("temperature") && typeNames.Contains("battery"))
            {
                control = new InfoTempBatSensor();
            }
            else if (typeNames.Contains("temperature"))
            {
                control = new InfoTempSensor();
            }
            else
            {
                control = new InfoHumSensor();
            }

            if (OnControlCreated != null && control != null)
            {
                SensorsControl.Add(sensor.Id, control);
                OnControlCreated(control);
            }
        }

        public void ShowAlert(Alert alert)
        {
            if (OnAlertCreated != null && alert != null)
            {
                OnAlertCreated(alert);
            }
        }

    }
}
