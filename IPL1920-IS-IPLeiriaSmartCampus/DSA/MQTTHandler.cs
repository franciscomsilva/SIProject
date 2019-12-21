using DSA.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json.Linq;

namespace DSA
{
    class MQTTHandler
    {
    
        private MQTTHandler()
        {
        }
        private static MQTTHandler instance = null;
        public static MQTTHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MQTTHandler();
                }
                return instance;
            }
        }
       
        int iLogin = 1;
        int iAlert = 1;
        int iUserID = 1;
        MqttClient mClient = null;
        List<string> topics = new List<string>();
   

        public void ConnectAndSubscribe()
        {
            if (mClient!=null &&  mClient.IsConnected)
            {
                Console.WriteLine("You're already connected, hurray!");
                return;
            }
            List<String> sensorsReadings;
            topics.Add("dataShow/start");
            topics.Add("alerts/readingType");
            topics.Add("alerts/login");
            topics.Add("alerts_data/new_alert");
            topics.Add("alerts/state");
            topics.Add("alerts_data/data");
            topics.Add("alerts/login/userID");


            foreach (Sensor sensor in SensorController.Instance.GetAllSensors()) //todos os canais de raw data
            {
                sensorsReadings = SensorController.Instance.GetSensorReadingTypes(sensor.Id);
                foreach (string reading in sensorsReadings)
                {
                    topics.Add( $"sensor_data/{sensor.Id}/{reading}");
                }
            }

            if (mClient!=null && mClient.IsConnected )
            {
                Console.WriteLine("Mqtt was connected to the broker already!");
            }
            Console.WriteLine("Connecting...");
            mClient = new MqttClient("mqtt.fmsilva.pt");
            
            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error Connecting to Message Broker!");
                return;
            }
            for (int h = 0; h < topics.Count; h++)
            {
                Console.WriteLine("Connecting to topic: "+topics[h]);
               mClient.Subscribe(new string[] { topics[h] },new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                Console.WriteLine("Connected sucessfully!");
            }
            mClient.MqttMsgPublishReceived += MClient_MqttMsgPublishReceived;
            
        }

        //TODO:funcao de bootup alerts/readingType
        public void publishData(string topic,string message)
        {
            if (!mClient.IsConnected)
            {
                Console.WriteLine("You'll need to connect to a broker before doing that!");
                return;
            }
            mClient.Publish(topic,Encoding.UTF8.GetBytes(message));
        }
        private void MClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {   
            //Acerca desta função: Nós vamos ter de separar os dados incoming apropriadamente para poderem ser parsed pelo controlador apropriado e reenviados para clean data, ou para poder
            //realizar operações non-sensor data related(IE ajudar o boot do alerts etc)
            string[] topics = e.Topic.Split("/");
            //Console.WriteLine(Encoding.UTF8.GetString(e.Message));
            //----------------------------------------DADOS DE SENSORES----------------------------------------------------------//
            if (topics[0].Equals("sensor_data"))
            {
                Console.WriteLine("Just received data from sensor number " + topics[1] + ", analyzing it!");
                DataController.Instance.ParseSensorData(int.Parse(topics[1]), topics[2],Encoding.UTF8.GetString(e.Message));
            }
            //---------------------------------------Bootup alerts--------------------------------------------------------------//
            if (topics[0].Equals("alerts"))
            { 
                if (topics[1].Equals("login")) //Login alerts so responde every other time, assim nao responde a mensagem da DSA e (consequentemente) nao 
                                               //rebenta
                {
                    if (topics.Length == 3 && topics[2].Equals("userID")) //redundante mas para escablidade
                    {
                       
                        iUserID++;
                        if (iUserID%2==0)
                        {
                            Console.WriteLine("Received a request to check a token and return a user id from alerts!");
                            string id = UserController.Instance.GetUserToken(Encoding.UTF8.GetString(e.Message));
                            publishData("alerts/login/userID", id);
                        }
                    }
                    else
                    {
                        
                        iLogin++;
                        if (iLogin % 2 == 0)
                        {
                            Console.WriteLine("Received a request to login by alerts!");
                            JObject tou = JObject.Parse(Encoding.UTF8.GetString(e.Message));
                            string[] results = LoginController.Instance.LoginAlerts((string)tou["username"], (string)tou["password"]);
                            publishData("alerts/login", "userID:" + results[0] + ":token:" + results[1]);

                        }
                    }
            }
            else
            {
                    if (topics[1].Equals("state"))
                    {
                        Console.WriteLine("Received a request to toggle the alert with id equal to " + Encoding.UTF8.GetString(e.Message));
                        AlertController.Instance.ToggleAlert(Encoding.UTF8.GetString(e.Message));
                    }
                    else // O resto
                    {
                        if (Encoding.UTF8.GetString(e.Message).ToLower().Equals("Request".ToLower()))
                        {
                            Console.WriteLine("Alerts requested reading types!");
                            publishData("alerts/readingType", JsonConvert.SerializeObject(SensorController.Instance.GetAllReadingTypes()));
                        }
                    }
            }
            }
            //----------------------------------------------Dados de alerts------------------------------------------------------//
            if (topics[0].Equals("alerts_data"))
            {
                
                if (topics[1].Equals("new_alert") )
                {
                    iAlert++;
                    if (iAlert%2==0)
                    {
                        Console.WriteLine("Registering a new alert as requested by alerts!");
                        Alert alert = JsonConvert.DeserializeObject<Alert>(Encoding.UTF8.GetString(e.Message));
                        AlertController.Instance.AddAlert(alert);
                        alert = AlertController.Instance.GetAllAlerts()[AlertController.Instance.GetAllAlerts().Count - 1];
                        publishData("alerts_data/new_alert", JsonConvert.SerializeObject(alert));
                    }
                }
                else{ //ALERTAS GERADOS WUHUUUUUUUUUU
                    Console.WriteLine("Registering a generated alert in the database");
                    AlertController.Instance.SaveGeneratedAlert(JsonConvert.DeserializeObject<GeneratedAlert>(Encoding.UTF8.GetString(e.Message)));
                }
            }
            if (topics[0].Equals("dataShow") && Encoding.UTF8.GetString(e.Message).ToLower().Equals("request"))
            {
                Console.WriteLine("Received a data retrieve request from data_show");
                string value = DataController.Instance.BootUpDataShow();
                publishData("dataShow/start",value);
            }
            

            
        }
    }
}
