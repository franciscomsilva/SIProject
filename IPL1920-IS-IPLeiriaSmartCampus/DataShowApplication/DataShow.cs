using System;
using Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace DataShowApplication
{
    public partial class DataShow : Form
    {
        public DataShow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppData.Instance.SetOnControllCreated(OnControlCreated);

            //add alerts list
            listBoxAlerts.Items.Clear();
            /*
            foreach(Alert alert in alerts) {
                listBoxAlerts.Items.Add(alert);
            }
            */

            Sensor sensor = new Sensor() { Id = 1, LocationID = 1, CreatedAt = new DateTime(2019, 12, 6), Personal = false, UserID = 1, Valid = true };

            AppData.Instance.AddSensor(sensor);
            AppData.Instance.AddLocation(new Location() { Id = 1, LocationName = "Piso Cima", GpsCoordenations = "12354" });

            AppData.Instance.SaveSensorValues(new BinarySensorData() { SensorId = 2, LocationId = 1, Date = new DateTime(2019, 12, 16), Temperature = 50F, Humidity = 55, HumidityTimestamp = new DateTime(2019, 11, 27), TemperatureTimestamp = new DateTime(2019, 11, 27) });
            AppData.Instance.SaveSensorValues(new BinarySensorData() { SensorId = 1, LocationId = 1, Date = new DateTime(2019, 12, 10), Temperature = 12.6F, Humidity = 40, HumidityTimestamp = new DateTime(2019, 12, 10), TemperatureTimestamp = new DateTime(2019, 12, 2) });
            AppData.Instance.SaveSensorValues(new BinarySensorData() { SensorId = 2, LocationId = 1, Date = new DateTime(2019, 12, 16), Temperature = 25.4F, Humidity = 30, HumidityTimestamp = new DateTime(2019, 12, 16), TemperatureTimestamp = new DateTime(2019, 12, 16) });

            this.ChartSensor.Series.Clear();

            this.ChartSensor.Titles.Add("Location " + sensor.LocationID + " Chart");


            foreach (String readingType in AppData.Instance.GetReadingTypesByLocation(sensor.LocationID))
            {
                Series series = this.ChartSensor.Series.Add(readingType);
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 2;
                series.MarkerStyle = MarkerStyle.Circle;
                ChartSensor.ChartAreas[0].AxisX.Interval = 2;

                foreach (Tuple<DateTime, float> readingTuple in AppData.Instance.GetReadingsByTypeAndLocation(sensor.LocationID, readingType))
                {
                    series.Points.AddXY(readingTuple.Item1, readingTuple.Item2);
                }
            }
        }

        private void OnControlCreated(UserControl sensorView)
        {
            flowLayoutPanelSensorsInfo.Controls.Add(sensorView);
        }

    }
}