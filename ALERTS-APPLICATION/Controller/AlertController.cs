using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ALERTS_APPLICATION.Controller
{
    class AlertController
    {
        private static AlertController instance = null;
        private static string FILE_PATH = "alerts_config.xml";
        private List<Alert> alerts;


        private AlertController() {
            this.alerts = load();

            if(this.alerts == null)
            {
                this.alerts = new List<Alert>();
            }
        
        }

        public static AlertController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlertController();
                }
                return instance;
            }
        }
        //TODO MUDAR O LOAD
        public List<Alert> load()
        {

            /*VERIFICA SE O FICHEIRO COM AS CONFIGURAÇÕES DOS ALERTAS EXISTEM*/
            if (File.Exists(FILE_PATH))
            {
                try
                {
                    string json = File.ReadAllText(FILE_PATH);
                    this.alerts = JsonConvert.DeserializeObject<List<Alert>>(json);

                    Console.WriteLine("ALERT CONFIG FILE READING SUCCESSFULL");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR_READING_FILE => " + ex.Message);
                }


                return this.alerts;
            }
            return null;
        }

        public Alert create(string description,int sensorID,List<Parameter> parameters)
        {
            /*GETS USER ID*/
            int userID = LoginController.Instance.checkUserLogin();

            Alert alert = new Alert
            {
                //  Parameters = parameters,
                Description = description,
                UserID = userID,
                Enabled = true,
                SensorID = sensorID,
                CreatedAt = DateTime.Now.ToString(),
                Parameters = new LinkedList<Parameter>(parameters)
            };

            return alert;
        }

        public void clean()
        {

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

        public bool save(Alert alert)
        {
            if(alert == null)
            {
                return false;
            }

            this.alerts.Add(alert);

            /*SAVES IN XML FILE*/
            XMLHandler.Instance.save(this.alerts);

            /*SENDS TO BROKER*/
            MQTTHandler.Instance.sendAlert(alert);

            return true;
        }

        public void update(Alert alert)
        {
            if(alert == null)
            {
                return;
            }

            bool success = XMLHandler.Instance.update(alert);


            if (!success)
            {
                Console.WriteLine("ERROR_UPDATING_ALERT_ID");
                return;
            }
            Console.WriteLine("UPDATED_ALERT_ID");

        }

        public void checkAlert(int sensorID,ReadingType readingType,int value)
        {
            XmlNodeList data = XMLHandler.Instance.getAlerts(sensorID);

            if(data == null)
                return;
            
            List<Alert> alertsSensor = new List<Alert>();
            int id;

            /*PARSE DATA*/
            foreach (XmlNode node in data)
            {
                id = int.Parse(node.ChildNodes.Item(6).InnerText);

                alertsSensor.Add(getAlert(id));
            }

            foreach(Alert i in alertsSensor)
            {
                foreach(Parameter parameter in i.Parameters)
                {
                    switch (parameter.Condition)
                    {
                        case "=":
                            if(parameter.Value == value)
                            {
                                //generate alert,send alert ID

                            }
                            break;

                        case "<":
                            if (parameter.Value < value)
                            {
                                //generate alert;

                            }
                            break;


                        case ">":
                            if (parameter.Value > value)
                            {
                                //generate alert;

                            }
                            break;
                    }
                }
            }



        }

        public void generateAlert(int alertID)
        {
            
            
        }

        public Alert getAlert(int id)
        {
            foreach(Alert i in this.alerts)
            {
                if(i.Id == id)
                {
                    return i;
                }
            }
            return null;
        }

    }
}
