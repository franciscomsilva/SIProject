using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ALERTS_APPLICATION
{ 
    public abstract class XMLHandler
    {
        private static string FILE_PATH = "alerts_config.xml";

        public static void save(List<Alert> alerts)
        {
            XmlDocument document = new XmlDocument();



            XmlNode alertsXML = document.CreateNode(XmlNodeType.Element, "alerts", "");

            document.AppendChild(alertsXML);

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


                    condition.InnerText = i.Condition;
                    //readingType.InnerText = i.ReadingType.ToString(); ;
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

                alertEl.AppendChild(parameters);
                alertEl.AppendChild(enabled);
                alertEl.AppendChild(description);
                alertEl.AppendChild(createdAt);
                alertEl.AppendChild(userID);


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

    }
}
