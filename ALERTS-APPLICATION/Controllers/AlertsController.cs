using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALERTS_APPLICATION.Controllers
{
    class AlertsController
    {
       
        private static AlertsController instance = null;
        private LinkedList<Alert> alerts;
        private static string FILE_PATH = "ALERTS.CONFIG";

        public static AlertsController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlertsController();
                }
                return instance;
            }
        }

        private AlertsController()
        {
            alerts = new LinkedList<Alert>();
        }

        public LinkedList<Alert> create(LinkedList<Parameter> parameters,string description,int sensorID)
        {

            /*CRIAR O Alert*/
            Alert alert = new Alert
            {
                Parameters = parameters,
                Description = description,
                UserID = 1,
                SensorID = sensorID,
                Enabled = true,
                DateCreated = DateTime.UtcNow
            };



            return save(alert);
        }
        public LinkedList<Alert> save(Alert alert)
        {
            if (alert == null)
            {
                return alerts;
            }

            alerts.AddLast(alert);


            /*SERIALIZAR E GUARDAR NUM FICHEIRO*/
            string json = JsonConvert.SerializeObject(alerts);

            try
            {
                File.WriteAllText(FILE_PATH, json);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR PERSISTING ALERTS -> " + ex.Message);
            }

            return alerts;
        }

        public LinkedList<Alert> read()
        {
            if (File.Exists(FILE_PATH))
            {
                try
                {
                    string json = File.ReadAllText(FILE_PATH);
                    alerts = JsonConvert.DeserializeObject<LinkedList<Alert>>(json);

                    Console.WriteLine("ALERTS CONFIG FILE READ");

                    return alerts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR READING ALERTS CONFIG FILE => " + ex.Message);
                }
            }
            return new LinkedList<Alert>();

        }

        public bool clear()
        {
            if (File.Exists(FILE_PATH))
            {
                try
                {
                    File.Delete(FILE_PATH);
                    Console.WriteLine("ALERTS CONFIG FILE DELETED");
                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR DELETING ALERTS CONFIG FILE => " + ex.Message);
                    return false;
                }

            }
            return false;
        }
    }
}
