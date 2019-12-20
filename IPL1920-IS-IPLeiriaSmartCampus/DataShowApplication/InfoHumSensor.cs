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

namespace DataShowApplication {
    public partial class InfoHumSensor : UserControl, ISensorView<HumSensorData> {
        public InfoHumSensor() {
            InitializeComponent();
        }

        public void Update(HumSensorData data) {
            //TODO NOME DO SENSOR
            lblInfoSensor.Text = AppData.Instance.FindSensorById(data.SensorId).Id.ToString();
            lblInfoLocation.Text = AppData.Instance.FindLocationById(data.LocationId).LocationName;
            lblInfoHumidity.Text = data.Humidity.ToString();
            lblInfoDate.Text = data.HumidityTimestamp.ToString();
        }
    }
}
