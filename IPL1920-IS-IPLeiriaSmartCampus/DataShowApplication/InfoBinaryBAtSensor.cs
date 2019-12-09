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
    public partial class InfoBinarySensor : UserControl, ISensorView<BinarySensorData> {
        public InfoBinarySensor() {
            InitializeComponent();
        }

        public void update(BinarySensorData data) {
            lblInfoSensor.Text = data.SensorName();
            lblInfoTemperature.Text = data.Temperature.ToString();
            lblInfoHumidity.Text = data.Humidity.ToString();
            lblInfoBaterry.Text = data.baterry.ToString();
            lblInfoDate.Text = data.date.ToString();
        }
    }
}
