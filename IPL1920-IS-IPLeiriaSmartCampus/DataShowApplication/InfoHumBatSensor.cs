using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace DataShowApplication
{
    public partial class InfoHumBatSensor : UserControl, ISensorView<HumBatSensorData>
    {
        public InfoHumBatSensor()
        {
            InitializeComponent();
        }

        public void Update(HumBatSensorData data)
        {
            //TODO NOME DO SENSOR
            lblInfoSensor.Text = AppData.Instance.FindSensorById(data.SensorId).Id.ToString();
            lblInfoLocation.Text = AppData.Instance.FindLocationById(data.LocationId).LocationName;
            lblInfoHumidity.Text = data.Humidity.ToString();
            lblInfoBattery.Text = data.Battery.ToString();
            lblInfoDate.Text = data.HumidityTimestamp + "\n" + data.BatteryTimestamp;
        }
    }
}
