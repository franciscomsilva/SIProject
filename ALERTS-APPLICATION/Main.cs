using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Xml;
using ALERTS_APPLICATION.Controller;

namespace ALERTS_APPLICATION
{
    public partial class Main : Form
    {
        private List<Parameter> parameters;
        private ErrorProvider errorProvider;
        private List<Alert> alerts;
        private List<ReadingType> readingTypes;
        private int userID;

        private static string FILE_PATH = "alerts_config.xml";


        public Main()
        {
            InitializeComponent();



        }

        public void setReadingTypes(List<ReadingType> readingTypes)
        {
            this.readingTypes = readingTypes;
        }

        private void Main_Load(object sender, EventArgs e)
        {

            parameters = new List<Parameter>();
            alerts = new List<Alert>();
            MQTTHandler.Instance.getReadingTypes();

            while (MQTTHandler.Instance.ReadingTypes == null){}
            
            this.readingTypes = MQTTHandler.Instance.ReadingTypes;

            /*GETS USER ID*/
            this.userID = LoginController.Instance.checkUserLogin();

       /*    if(this.userID == -1)
            {
               

                this.Close();
            }
            */
       

            cbReadingType.DataSource = this.readingTypes;
            cbReadingType.ValueMember = "MeasureName";


            cbParameterCondition.SelectedIndex = 0;

            lvParameters.View = View.Details;
            lvParameters.Columns.Add("Condition");
            lvParameters.Columns.Add("Data Type");
            lvParameters.Columns.Add("Value");

            lvAlerts.View = View.Details;
            lvAlerts.Columns.Add("Number Of Parameters");
            lvAlerts.Columns.Add("Description");
            lvAlerts.Columns.Add("Creation Date");
            lvAlerts.Columns.Add("Enabled");



            errorProvider = new ErrorProvider();

            errorProvider.SetIconAlignment(txtAlertDescription, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(txtAlertDescription, 3);
            errorProvider.SetIconAlignment(nrParameterValue, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(nrParameterValue, 3);
            errorProvider.SetIconAlignment(btnAddParameter, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(btnAddParameter, 3);



            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;


            /*VERIFICA SE O FICHEIRO COM AS CONFIGURAÇÕES DOS ALERTAS EXISTEM*/
            if (File.Exists(FILE_PATH))
            {
                try
                {
                    string json = File.ReadAllText(FILE_PATH);
                    alerts = JsonConvert.DeserializeObject<List<Alert>>(json);

                    Console.WriteLine("ALERT CONFIG FILE READING SUCCESSFULL");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR_READING_FILE => " + ex.Message);
                }

                ListViewItem item = null;


                /*CARREGA O ALERTAS NA LISTA*/
                foreach (Alert alertI in alerts)
                {
                    item = new ListViewItem(new string[] { alertI.Parameters.Count.ToString(), alertI.Description, alertI.CreatedAt, alertI.Enabled.ToString() });
                    lvAlerts.Items.Add(item);
                }


            }
        }



        private void btnAdicionar_Click(object sender, EventArgs e)
        {


            string condition = cbParameterCondition.SelectedItem.ToString();

            ReadingType dataType = (ReadingType)cbReadingType.SelectedItem;



            decimal value = nrParameterValue.Value;

            Parameter parameter = new Parameter
            {
                Condition = condition,
                ReadingType = (ReadingType)cbReadingType.SelectedItem,
                Value = value
            };

            parameters.Add(parameter);

            ListViewItem item = null;



            lvParameters.Items.Clear();
            foreach (Parameter parameterI in parameters)
            {
                item = new ListViewItem(new string[] { parameterI.Condition,"boas", parameterI.Value.ToString() });
                lvParameters.Items.Add(item);
            }



        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCriarAlert_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(btnAddParameter, "");
            errorProvider.SetError(txtAlertDescription, "");


            if (txtAlertDescription.Text.Length <= 0)
            {
                errorProvider.SetError(txtAlertDescription, "Description is mandatory");
                return;
            }

            if (parameters.Count <= 0)
            {
                errorProvider.SetError(btnAddParameter, "At least one parameter is neccessary to create the alert");
                return;
            }

            if(nrSensorID.Value <= 0)
            {
                errorProvider.SetError(nrSensorID, "Sensor ID must be positive integer");
                return;
            }


            /*CRIAR O ALERTA*/
            Alert alert = new Alert
            {
              //  Parameters = parameters,
                Description = txtAlertDescription.Text,
                UserID = 1,
                Enabled = true,
                SensorID = Convert.ToInt32(nrSensorID.Value),
                CreatedAt = DateTime.UtcNow.ToShortDateString()
            };

            saveAlert(alert);


            /*LIMPA OS DADOS*/
            txtAlertDescription.Clear();
            nrParameterValue.Value = 0;
            nrSensorID.Value = 0;

            // cbReadingType.SelectedIndex = 0;
            cbParameterCondition.SelectedIndex = 0;

            lvParameters.Items.Clear();

            parameters.Clear();



        }


        private void saveAlert(Alert alert)
        {
            if (alert == null)
            {
                return;
            }

            alerts.Add(alert);

            /*ATUALIZA LISTA*/
            ListViewItem item = null;
            lvAlerts.Items.Clear();

            XMLHandler.save(this.alerts);

            foreach(Alert alertI in this.alerts)
            {
                item = new ListViewItem(new string[] { alertI.Parameters.Count.ToString(), alertI.Description, alertI.CreatedAt, alertI.Enabled.ToString() });
                lvAlerts.Items.Add(item);
            }

          
        }

        private void lvParameters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLimparAlerts_Click(object sender, EventArgs e)
        {
            alerts.Clear();
            lvAlerts.Items.Clear();

            /*APAGA O FICHEIRO QUE GUARDA OS ALERTAS*/

            if (File.Exists(FILE_PATH))
            {
                try
                {
                    File.Delete(FILE_PATH);
                    Console.WriteLine("ALERT CONFIG FILE DELETING SUCCESSFULL");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR_DELETING_FILE => " + ex.Message);

                }
            }
        }

        private void btnLimparAlertas_Click(object sender, EventArgs e)
        {

        }
    }
}