using System;
using System.Collections.Generic;
using System.Text;
using ALERTS_APPLICATION.Controller;
using Models;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ALERTS_APPLICATION
{
    class MQTTHandler
    {
        private MqttClient mClient = null;
        public List<string> topics = new List<string>();
        private static MQTTHandler instance = null;
        private int i = 2;
        private string[] loginArray;
        private string userID;
        

        public List<ReadingType> ReadingTypes { get; set; }
        public string UserToken { get; set; }


        private MQTTHandler()
        {
            this.topics.Add("alerts/login");
            this.topics.Add("alerts/readingType");
            this.topics.Add("alerts_data/new_alert");
            this.topics.Add("clean_data/4");
            this.topics.Add("alerts/state");
            this.topics.Add("alerts/login/userID");
            ConnectAndSubscribe();
        }
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
        
        


        public void ConnectAndSubscribe()
        {
            if (mClient != null && mClient.IsConnected)
            {
                Console.WriteLine("ERROR_CONNECTION_EXISTED");
                return;
            }

            Console.WriteLine("CONNECTING TO BROKER...");
            mClient = new MqttClient("mqtt.fmsilva.pt");

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("ERROR_CONNECTING_BROKER!");
                return;
            }
            for (int h = 0; h < this.topics.Count; h++)
            {
                Console.WriteLine("Connecting to topic number " + h + ":" + this.topics[h]);
                mClient.Subscribe(new string[] { this.topics[h] }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                Console.WriteLine("Connected sucessfully!");
            }
            mClient.MqttMsgPublishReceived += MClient_MqttMsgPublishReceived;

        }
        public void publishData(string topic, string message)
        {
            if (!mClient.IsConnected)
            {
                Console.WriteLine("ERROR_BROKER_NOT_CONNECTED");
                return;
            }
            mClient.Publish(topic, Encoding.UTF8.GetBytes(message));
        }
        private void MClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            string[] data = e.Topic.Split('/');
            int sensorID = 0;
            Console.WriteLine(Encoding.UTF8.GetString(e.Message));



            if (data[0].Equals("clean_data"))
            {
                sensorID = int.Parse(data[1]);

                SensorData sensorData = JsonConvert.DeserializeObject<SensorData>(Encoding.UTF8.GetString(e.Message));

                AlertController.Instance.checkAlert(sensorID,sensorData);

                sensorID = 0;

            }

            if (data.Length > 1)
            {
               
                /* CALLS LOGIN TO PERSIST USER ID*/
                if (data[1].Equals("login") && Encoding.UTF8.GetString(e.Message).Contains("userID:"))
                {
                    loginArray = Encoding.UTF8.GetString(e.Message).Split(':');

                    LoginController.Instance.saveUserIDToken(int.Parse(loginArray[1]), loginArray[3]);
                }

                /*RECEIVE READING TYPES*/
                if (data[1].Equals("readingType") && !Encoding.UTF8.GetString(e.Message).ToLower().Equals("request"))
                {

                    this.ReadingTypes = JsonConvert.DeserializeObject<List<ReadingType>>(Encoding.UTF8.GetString(e.Message));

                }

                /*RECEIVES ALERT WITH ID*/
                if (data[1].Equals("new_alert"))
                {
                    i++;
                    if (i % 2 == 0)
                    {

                        AlertController.Instance.update(JsonConvert.DeserializeObject<Alert>(Encoding.UTF8.GetString(e.Message)));
                        i++;
                    }
                }
            }

            if(data.Length > 2 && e.Message.Length == 1)
            {
                /*LOGIN USERID*/
                if (data[2].Equals("userID"))
                {
                    userID = Encoding.UTF8.GetString(e.Message);
                    LoginController.Instance.UserID = int.Parse(userID);
                }
            }
        }

        public void login(string username, string password)
        {
            string json = JsonConvert.SerializeObject(new { username, password });
            publishData("alerts/login", json);

        }

        public void getReadingTypes()
        {
            publishData("alerts/readingType", "request");
        }

        public void sendAlert(Alert alert)
        {
            if(alert == null)
            {
                return;
            }

            string json = JsonConvert.SerializeObject(alert);

            publishData("alerts_data/new_alert", json);

        }

        public void sendGeneratedAlert(GeneratedAlert alert)
        {

            if (alert == null)
            {
                return;
            }

            string json = JsonConvert.SerializeObject(alert);

            publishData("alerts_data/data", json);


        }

        public void changeAlertState(int alertID)
        {
            publishData("alerts/state", alertID.ToString());

        }

        public void sendToken(string token)
        {
            publishData("alerts/login/userID", token);
        }

    }
}