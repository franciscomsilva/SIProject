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
            AppData.Instance.AddLocation(new Location() { Id = 1, LocationName = "Test location", GpsCoordenations = "" });
            Sensor sensor = new Sensor() { Id = 1, UserID = 1, LocationID = 1, Valid = true, CreatedAt = "", Description = "Sensor temperatura e humidade", Personal = false };
            AppData.Instance.AddReadingType(new ReadingType { Id = 1, SensorId = 1, MaxValue = "100", MeasureName = "Temperature", MeasureType = "Temperature" });
            AppData.Instance.AddReadingType(new ReadingType { Id = 2, SensorId = 1, MaxValue = "50", MeasureName = "Humidity", MeasureType = "Humidity" });
            AppData.Instance.AddSensor(sensor);

            var binarySensor = new BinarySensorData() { SensorId = 1, LocationId = 1, Date = "", Temperature = 17F, Humidity = 80, HumidityTimestamp = new DateTime(2019, 12, 20), TemperatureTimestamp = new DateTime(2019, 12, 20) };
            AppData.Instance.SaveSensorValues(binarySensor);
            
        }
    }
}