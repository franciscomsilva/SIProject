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
    public partial class InfoBinaryBatSensor : ISensorView<BinaryBatSensorData>
    {
        public InfoBinaryBatSensor()
        {
            InitializeComponent();
        }

        public override void Update(BinaryBatSensorData data)
        {
            //TODO NOME DO SENSOR
            lblInfoSensor.Text = AppData.Instance.FindSensorById(data.SensorId).Id.ToString();
            lblInfoLocation.Text = AppData.Instance.FindLocationById(data.LocationId).LocationName;
            lblInfoTemperature.Text = data.Temperature.ToString();
            lblInfoHumidity.Text = data.Humidity.ToString();
            lblInfoBattery.Text = data.Battery.ToString();
            lblInfoDate.Text = data.TemperatureTimestamp + "\n" + data.HumidityTimestamp + "\n" + data.BatteryTimestamp;
        }
    }
}