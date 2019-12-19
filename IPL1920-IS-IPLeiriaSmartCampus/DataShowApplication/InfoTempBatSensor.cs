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
    public partial class InfoTempBatSensor : UserControl, ISensorView<TempBatSensorData>
    {
        public InfoTempBatSensor()
        {
            InitializeComponent();
        }

        public void update(TempBatSensorData data)
        {
            lblInfoLocation.Text = AppData.Instance.FindLocationById(data.LocationId).LocationName;
        }
    }
}
