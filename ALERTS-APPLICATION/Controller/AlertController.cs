using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ALERTS_APPLICATION.Controller
{
    class AlertController
    {
        private static AlertController instance = null;
        private static string FILE_PATH = "alerts_config.xml";
        public List<Alert> alerts;
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
            this.alerts = new List<Alert>();

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
                        Id = int.Parse(node.ChildNodes.Item(6).InnerText),
                        SensorID = int.Parse(node.ChildNodes.Item(5).InnerText),
                        UserID = int.Parse(node.ChildNodes.Item(4).InnerText)

                    };
                    XmlNode parametersXML = node.ChildNodes.Item(0);
                    foreach (XmlNode parameterI in parametersXML.ChildNodes)
                    {
                        parameter = new Parameter
                        {
                            Condition = parameterI.ChildNodes.Item(0).InnerText,
                            ReadingType = new ReadingType { MeasureName = parameterI.ChildNodes.Item(1).InnerText },
                            Value = parameterI.ChildNodes.Item(2).InnerText
                        };
                        parameters.Add(parameter);
                    }

                    alert.Parameters = parameters;

                    this.alerts.Add(alert);
                    parameters = new List<Parameter>();
                }
                return this.alerts;
            }
            return new List<Alert>();
        }

        public Alert create(string description,int sensorID,List<Parameter> parameters)
        {
            /*GETS USER ID*/
            int userID = LoginController.Instance.checkUserLogin();

            if(userID == -1)
            {
                return null;
            }

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
            this.alerts.Clear();
            XMLHandler.Instance.deleteFile();
        }

        public bool save(Alert alert)
        {
            if(alert == null)
            {
                return false;
            }

            this.alerts.Add(alert);

            /*SAVES IN XML FILE*/
            XMLHandler.Instance.save(alert);

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
            load();
            Console.WriteLine("UPDATED_ALERT_ID");

        }

        public void checkAlert(int sensorID,SensorData sensorData)
        {
            XmlNodeList data = XMLHandler.Instance.getAlerts(sensorID);

            if(data == null)
                return;
            
            List<Alert> alertsSensor = new List<Alert>();
            Alert alert = null;
            int id;

            string measure_name = sensorData.MeasureName.ToLower(); ;
            decimal value = decimal.Parse(sensorData.Value);
            decimal parameterValue = 0;
            decimal value2 = 0;
            decimal value3 = 0;
            string[] values;

            /*PARSE DATA*/
            foreach (XmlNode node in data)
            {
                id = int.Parse(node.ChildNodes.Item(6).InnerText);

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
                    if (parameter.Condition.Equals("<>"))
                    {
                        values = parameter.Value.Split(':');
                        value2 = decimal.Parse(values[0]);
                        value3 = decimal.Parse(values[1]);
                    }
                    else
                    {
                        parameterValue = decimal.Parse(parameter.Value);
                    }
                    if (parameter.ReadingType.MeasureName.ToLower().Equals(measure_name) && i.Enabled)//IF READING TYPE EQUALS EX: HUMIDADE=HUMIDADE
                    {
                        switch (parameter.Condition)
                        {
                            case "=":
                                if (parameterValue == value)
                                {
                                    //generate alert,send alert ID
                                    generateAlert(i.Id);
                                }
                                break;

                            case "<":
                                if (value < parameterValue)
                                {
                                    //generate alert;
                                    generateAlert(i.Id);

                                }
                                break;


                            case ">":
                                if (value > parameterValue)
                                {
                                    //generate alert;
                                    generateAlert(i.Id);
                                }
                                break;
                            case "<>":
                                if(value > value2 && value < value3)
                                {
                                    generateAlert(i.Id);
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

        public void disableAlert(int alertID)
        {
            /*UPDATES XML*/
            XMLHandler.Instance.updateEnabled(alertID);
            load();

            /* SEND TO CHANNEL USING MQQTTHANDLER*/
            MQTTHandler.Instance.changeAlertState(alertID);

        }
    }
}
