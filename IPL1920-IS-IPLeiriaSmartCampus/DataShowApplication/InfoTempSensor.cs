using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataShowApplication {
    public partial class InfoTempSensor : UserControl, ISensorView<TemperatureSensorData> {
        public InfoTempSensor() {
            InitializeComponent();
        }

        public void update(TemperatureSensorData data) {
            lblInfoSensor.Text = data.sensor;
            lblInfoLocation.Text = data.temperature.ToString();
            lblInfoTemperature.Text = data.baterry.ToString();
            lblInfoDate.Text = data.date.ToString();
        }
    }
}
