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
        public  List<GeneratedAlert> generatedAlerts;


        private AlertController() {
            this.alerts = new List<Alert>();

            this.alerts = load();

            this.generatedAlerts = new List<GeneratedAlert>();
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

        public List<Alert> getAllAlerts()
        {
            return this.alerts;
        }

        public List<Alert> load()
        {

            /*VERIFICA SE O FICHEIRO COM AS CONFIGURAÇÕES DOS ALERTAS EXISTEM*/
            if (File.Exists(FILE_PATH))
            {
                XmlNodeList nodeList = XMLHandler.Instance.getAllAlerts();
                Alert alert = null;
                List<Parameter> parameters = new List<Parameter>();
                Parameter parameter = null;

                foreach (XmlNode node in nodeList)
                {
                    alert = new Alert
                    {
                        CreatedAt = node.ChildNodes.Item(3).InnerText,
                        Description = node.ChildNodes.Item(2).InnerText,
                        Enabled = bool.Parse(node.ChildNodes.Item(1).InnerText),
                        Id = int.Parse(node.ChildNodes.Item(5).InnerText),
                        SensorID = int.Parse(node.ChildNodes.Item(6).InnerText),
                        UserID = int.Parse(node.ChildNodes.Item(4).InnerText)

                    };
                    XmlNode parametersXML = node.ChildNodes.Item(0);
                    foreach (XmlNode parameterI in parametersXML.ChildNodes)
                    {
                        parameter = new Parameter
                        {
                            Condition = parameterI.ChildNodes.Item(0).InnerText,
                            Value = decimal.Parse(parameterI.ChildNodes.Item(2).InnerText)
                        };
                        parameters.Add(parameter);
                    }

                    alert.Parameters = parameters;

                    this.alerts.Add(alert);
                }
                return this.alerts;
            }
            return new List<Alert>();
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
                Parameters = new List<Parameter>(parameters)
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
            Alert alert = null;
            int id;

            /*PARSE DATA*/
            foreach (XmlNode node in data)
            {
                id = int.Parse(node.ChildNodes.Item(5).InnerText);

                alert = getAlert(id);

                if(alert != null)
                {
                    alertsSensor.Add(alert);

                }
            }

            foreach(Alert i in alertsSensor)
            {
                foreach(Parameter parameter in i.Parameters)
                {
                    if (parameter.Condition.ToLower().Equals(parameter.ReadingType.MeasureName))
                    {
                        switch (parameter.Condition)
                        {
                            case "=":
                                if (parameter.Value == value)
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



        }

        public void generateAlert(int alertID)
        {
            /*CREATE GENERATED ALERT*/
            GeneratedAlert generatedAlert = new GeneratedAlert
            {
                alert_id = alertID,
                timestamp = DateTime.Now.ToString()
            };

            generatedAlerts.Add(generatedAlert);

            sendGeneratedAlert(generatedAlert);

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

        public void sendGeneratedAlert(GeneratedAlert alert)
        {
            if(alert == null)
            {
                return;
            }

            MQTTHandler.Instance.sendGeneratedAlert(alert);
        }

    }
}
