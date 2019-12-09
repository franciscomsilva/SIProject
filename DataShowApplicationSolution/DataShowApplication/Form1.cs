using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataShowApplication {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            flowLayoutPanelSensorsInfo.Controls.Add(new InfoBinarySensor());
            flowLayoutPanelSensorsInfo.Controls.Add(new InfoBinarySensor());
            flowLayoutPanelSensorsInfo.Controls.Add(new InfoHumiditySensor());
            flowLayoutPanelSensorsInfo.Controls.Add(new InfoHumiditySensor());
            flowLayoutPanelSensorsInfo.Controls.Add(new InfoTemperatureSensor());
            flowLayoutPanelSensorsInfo.Controls.Add(new InfoTemperatureSensor());

            //add alerts list
            listBoxAlerts.Items.Clear();
            /*foreach(Alert alert in alerts) {
                listBoxAlerts.Items.Add(alert);
            }*/
        }
    }
}
