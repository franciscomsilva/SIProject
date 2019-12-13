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
using System.Threading;

namespace ALERTS_APPLICATION
{
    public partial class Main : Form
    {
        private List<Alert> alerts;
        private List<GeneratedAlert> generatedAlerts;
        private List<Parameter> parameters;
        private ErrorProvider errorProvider;
        private List<ReadingType> readingTypes;
        private int userID;
        private int size = 0;
        private Thread t;

        


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
            Console.WriteLine("STARTING_MAIN_FORM");

            this.parameters = new List<Parameter>();
            this.alerts = new List<Alert>();

            /*READS SAVED ALERTS*/
            MQTTHandler.Instance.getReadingTypes();

            DateTime startTime = DateTime.Now;
            while (MQTTHandler.Instance.ReadingTypes == null && DateTime.Now.Subtract(startTime).Seconds <= 5)
            { }

            this.readingTypes = MQTTHandler.Instance.ReadingTypes;

            /*GETS USER ID*/
            this.userID = LoginController.Instance.checkUserLogin();

            

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

            /*CREATES THREAD TO CHECK FOR NEW GENERATED ALERTS*/
            t = new Thread(checkGeneratedAlerts);


            /*LOAD ALERTS TO LIST*/
            loadAlertsToList();

     
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
                item = new ListViewItem(new string[] { parameterI.Condition,parameter.ReadingType.ToString(), parameterI.Value.ToString() });
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
            Alert alert = AlertController.Instance.create(txtAlertDescription.Text,Convert.ToInt32(nrSensorID.Value),this.parameters);

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

            AlertController.Instance.save(alert);

            loadAlertsToList();
          
        }

        public void checkGeneratedAlerts()
        { 
            while (true)
            {
                if(AlertController.Instance.generatedAlerts.Count > size)
                {
                    this.generatedAlerts = AlertController.Instance.generatedAlerts;
                    size = this.generatedAlerts.Count;

                    /*ENVIA A FUNCAO PARA ATUALIZAR A UI PARA A THREAD RESPONSAVEL*/
                    this.Invoke((MethodInvoker)delegate
                    {
                        loadGeneratedAlertsToList();
                    });
                }

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
            AlertController.Instance.clean();
        }

        private void loadAlertsToList()
        {
            lvAlerts.Items.Clear();

            /*LOADS ALERTS DATA*/
            ListViewItem item = null;

            this.alerts = AlertController.Instance.getAllAlerts();


            /*CARREGA O ALERTAS NA LISTA*/
            foreach (Alert alertI in alerts)
            {
                item = new ListViewItem(new string[] { alertI.Parameters.Count.ToString(), alertI.Description, alertI.CreatedAt, alertI.Enabled.ToString() });
                lvAlerts.Items.Add(item);
            }
        }

        private void loadGeneratedAlertsToList()
        {
            lvGeneratedAlerts.Items.Clear();

            /*LOADS ALERTS DATA*/
            ListViewItem item = null;

            Alert alert = null;

            /*CARREGA O ALERTAS NA LISTA*/
            foreach (GeneratedAlert generatedAlert in this.generatedAlerts)
            {
                alert = AlertController.Instance.getAlert(generatedAlert.alert_id);

                item = new ListViewItem(new string[] {alert.Id.ToString(),alert.Description,generatedAlert.timestamp });
                lvGeneratedAlerts.Items.Add(item);
            }
        }
    }
}