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
            //lblInfoSensor.Text = data.sensor;
            //lblInfoLocation.Text = data.temperature.ToString();
            //lblInfoTemperature.Text = data.baterry.ToString();
            //lblInfoDate.Text = data.date.ToString();
        }
    }
}
