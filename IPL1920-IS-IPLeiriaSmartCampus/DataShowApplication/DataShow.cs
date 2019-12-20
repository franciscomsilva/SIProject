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
            AppData.Instance.SetOnAlertCreated(OnAlertCreated);

            return;
            //add alerts list
            listBoxAlerts.Items.Clear();


            Sensor sensor = new Sensor() { Id = 1, LocationID = 1, CreatedAt = new DateTime(2019, 12, 6), Personal = false, UserID = 1, Valid = true };

            AppData.Instance.AddSensor(sensor);
            AppData.Instance.AddLocation(new Location() { Id = 1, LocationName = "Piso Cima", GpsCoordenations = "12354" });

            /*
            AppData.Instance.SaveSensorValues(new BinarySensorData() { SensorId = 2, LocationId = 1, Date = new DateTime(2019, 12, 16), Temperature = 50F, Humidity = 55, HumidityTimestamp = new DateTime(2019, 11, 27), TemperatureTimestamp = new DateTime(2019, 11, 27) });
            AppData.Instance.SaveSensorValues(new BinarySensorData() { SensorId = 1, LocationId = 1, Date = new DateTime(2019, 12, 10), Temperature = 12.6F, Humidity = 40, HumidityTimestamp = new DateTime(2019, 12, 10), TemperatureTimestamp = new DateTime(2019, 12, 2) });
            AppData.Instance.SaveSensorValues(new BinarySensorData() { SensorId = 2, LocationId = 1, Date = new DateTime(2019, 12, 16), Temperature = 25.4F, Humidity = 30, HumidityTimestamp = new DateTime(2019, 12, 16), TemperatureTimestamp = new DateTime(2019, 12, 16) });

            this.ChartSensor.Series.Clear();

            */
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

        private void OnAlertCreated(Alert alert)
        {
            string mensagem = "(" + alert.CreatedAt + ") - " + AppData.Instance.FindSensorById(alert.SensorID).Id;
            string sensorDescription = AppData.Instance.FindSensorById(alert.SensorID).Description;
            mensagem += sensorDescription == null ? " - " + alert.Description : " (" + sensorDescription + ") - " + alert.Description;

            listBoxAlerts.Items.Add(mensagem);
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {

            Alert alert = new Alert() { Id = 1, SensorID = 1, Description = "Alerta", UserID = 1, Enabled = true, CreatedAt = "12-12-2019" };
            AppData.Instance.ShowAlert(alert);
        }

        private void btnSensors_Click(object sender, EventArgs e)
        {
            Sensor sensor = new Sensor() { Id = 1, UserID = 1, LocationID = 1, Valid = true, CreatedAt = new DateTime(2019, 12, 20), Description = "Sensor temperatura e humidade", Personal = false };
            AppData.Instance.AddReadingType(new ReadingType { Id = 1, SensorId = 1, MaxValue = "100", MeasureName = "Temperature", MeasureType = "Temperature" });
            AppData.Instance.AddReadingType(new ReadingType { Id = 2, SensorId = 1, MaxValue = "50", MeasureName = "Humidity", MeasureType = "Humidity" });
            AppData.Instance.CreateSensorsControl(sensor);

            var binarySensor = new BinarySensorData() { SensorId = 1, LocationId = 1, Date = new DateTime(2019, 12, 16), Temperature = 17F, Humidity = 80, HumidityTimestamp = new DateTime(2019, 12, 20), TemperatureTimestamp = new DateTime(2019, 12, 20) };
            AppData.Instance.SaveSensorValues(binarySensor);
            
        }
    }
}