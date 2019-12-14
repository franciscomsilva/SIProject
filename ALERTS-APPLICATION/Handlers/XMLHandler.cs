using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ALERTS_APPLICATION
{ 
    public  class XMLHandler
    {
        private static string FILE_PATH = "alerts_config.xml";
        private static XMLHandler instance = null;
        private XmlDocument document;
        private XmlNode alertsXML;


        private XMLHandler()
        {
            document = new XmlDocument();

            if (File.Exists(FILE_PATH))
            {
                document.Load(FILE_PATH);
                alertsXML = document.SelectSingleNode("/alerts");
            }
            else
            {
                alertsXML = document.CreateNode(XmlNodeType.Element, "alerts", "");
                document.AppendChild(alertsXML);
            }
        }

        public static XMLHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XMLHandler();
                }
                return instance;
            }
        }


        public void save(List<Alert> alerts)
        {
     
            XmlElement sensorID = null;
            XmlElement parameters = null;
            XmlElement enabled = null;
            XmlElement description = null;
            XmlElement createdAt = null;
            XmlElement userID = null;
            XmlElement alertEl = null;
            XmlElement parameter = null;
            XmlElement condition = null;
            XmlElement readingType = null;
            XmlElement value = null;
            XmlElement sensorIDElement = null;

            /*CARREGA O ALERTAS NA LISTA*/
            foreach (Alert alertI in alerts)
            {
               

                sensorID = (XmlElement)document.SelectSingleNode($"/alerts/sensorID[@id='{alertI.SensorID.ToString()}']");

                if (sensorID == null)
                {
                    sensorID = document.CreateElement("sensorID");
                    sensorID.SetAttribute("id", alertI.SensorID.ToString());
                }

                alertEl = document.CreateElement("alert");

                parameters = document.CreateElement("parameters");
                enabled = document.CreateElement("enabled");
                description = document.CreateElement("description");
                createdAt = document.CreateElement("createdAt");
                userID = document.CreateElement("userID");

                /*SAVES PARAMETERS*/
                foreach (Parameter i in alertI.Parameters)
                {
                    parameter = document.CreateElement("parameter");
                    condition = document.CreateElement("condition");
                    readingType = document.CreateElement("readingType");
                    value = document.CreateElement("value");
                    sensorIDElement = document.CreateElement("sensorID");


                    condition.InnerText = i.Condition;
                    readingType.InnerText = i.ReadingType.MeasureName;
                    value.InnerText = i.Value.ToString();

                    parameter.AppendChild(condition);
                    parameter.AppendChild(readingType);
                    parameter.AppendChild(value);

                    parameters.AppendChild(parameter);

                }

                alertEl.AppendChild(parameters);

                enabled.InnerText = alertI.Enabled.ToString();
                description.InnerText = alertI.Description;
                createdAt.InnerText = alertI.CreatedAt;
                userID.InnerText = alertI.UserID.ToString();
                sensorIDElement.InnerText = alertI.SensorID.ToString();


                alertEl.AppendChild(parameters);
                alertEl.AppendChild(enabled);
                alertEl.AppendChild(description);
                alertEl.AppendChild(createdAt);
                alertEl.AppendChild(userID);
                alertEl.AppendChild(sensorIDElement);


                sensorID.AppendChild(alertEl);

                alertsXML.AppendChild(sensorID);

                sensorID = null;

            }


            try
            {
                document.Save(FILE_PATH);
                Console.WriteLine("ALERT CONFIG FILE SAVED");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR_SAVING_FILE => " + ex.Message);
            }

        }


        public bool update(Alert alert)
        {
            if(alert == null)
            {
                return false;
            }

            XmlElement element = null;
            int sensorID = alert.SensorID;

            string xPath = $"/alerts/sensorID[@id='{sensorID}']/alert[last()]";

            element = (XmlElement)document.SelectSingleNode(xPath);
            
            if(element == null)
            {
                return false;
            }

            XmlElement id = document.CreateElement("id");

            id.InnerText = alert.Id.ToString();

            element.AppendChild(id);

            document.Save(FILE_PATH);

            return true;

        }

        private bool checkIfFileExists()
        {
            return File.Exists(FILE_PATH);
        }

        public XmlNodeList getAlerts(int sensorID)
        {
        
            string xpath = $"/alerts/sensorID[@id='{sensorID}']/alert";

            if (checkIfFileExists()){
                return document.SelectNodes(xpath);
            }

            return null;
        } 

        public XmlNodeList getAllAlerts()
        {
            /*GETS ALL ALERTS FROM FILE*/
            string xpath = "//alert";

            return document.SelectNodes(xpath);


        }

        public bool updateEnabled(int alertID)
        {
            string xpath = $"//alert[id='{alertID}']";

            XmlNode node = document.SelectSingleNode(xpath);

            if(node == null)
            {
                return false;
            }
            
            bool value = bool.Parse(node.ChildNodes.Item(1).InnerText);

            value = value == false ? value = true : value = false;

            node.ChildNodes.Item(1).InnerText = value.ToString();

            document.Save(FILE_PATH);

            return true;

        }


    }
}
