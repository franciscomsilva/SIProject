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

namespace DataShowApplication
{
    public partial class DataShow : Form
    {
        List<SensorData> Sensors = new List<SensorData>()
        {
            new BinarySensorData(){SensorId=1, LocationId=1, Date= new DateTime(2019, 12,10), Temperature=12.6F, Humidity=40, HumidityTimestamp= new DateTime(2019, 12,10), TemperatureTimestamp=new DateTime(2019, 12,2)},
            new TempSensorData(){SensorId=1, LocationId=1, Date=new DateTime(2019, 12,10), Temperature=20, TemperatureTimestamp=new DateTime(2019, 1,2)},
        };


        public DataShow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanelSensorsInfo.Controls.Add(new InfoBinarySensor());
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

            AppData.Instance.SaveSensorValues(new BinarySensorData() { SensorId = 1, LocationId = 1, Date = new DateTime(2019, 12, 10), Temperature = 12.6F, Humidity = 40, HumidityTimestamp = new DateTime(2019, 12, 10), TemperatureTimestamp = new DateTime(2019, 12, 2) });
        }
    }
}
