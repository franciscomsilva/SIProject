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
    public partial class InfoTempSensor : UserControl, ISensorView<TempSensorData> {
        public InfoTempSensor() {
            InitializeComponent();
        }

        public void update(TempSensorData data) {

            lblInfoSensor.Text = AppData.Instance.FindSensorById(data.SensorId).Id.ToString();
            lblInfoLocation.Text = AppData.Instance.FindLocationById(data.LocationId).LocationName;  
            lblInfoTemperature.Text = data.Temperature.ToString();
            lblInfoDate.Text = data.TemperatureTimestamp.ToString();
        }
    }
}
