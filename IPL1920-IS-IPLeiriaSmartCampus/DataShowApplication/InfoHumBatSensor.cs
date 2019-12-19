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

        public void update(HumBatSensorData data)
        {
            throw new NotImplementedException();
        }
    }
}
