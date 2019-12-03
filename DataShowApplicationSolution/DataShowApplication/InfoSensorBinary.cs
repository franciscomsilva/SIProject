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
    public partial class InfoSensorBinary : UserControl {
        public InfoSensorBinary() {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(new Label { Text = "Ola" }, 1, 0);
        }

    }
}
