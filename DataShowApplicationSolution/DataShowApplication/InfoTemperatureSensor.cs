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
    public partial class InfoTemperatureSensor : UserControl, ISensorView<TemperatureSensorData> {
        public InfoTemperatureSensor() {
            InitializeComponent();
        }

        public void update(TemperatureSensorData data) {
            lblInfoSensor.Text = data.sensor;
            lblInfoTemperature.Text = data.temperature.ToString();
            lblInfoBaterry.Text = data.baterry.ToString();
            lblInfoDate.Text = data.date.ToString();
        }
    }
}
