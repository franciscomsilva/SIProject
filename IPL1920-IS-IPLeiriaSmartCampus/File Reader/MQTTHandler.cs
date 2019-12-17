using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace File_Reader
{
    class MQTTHandler
    {
        private MqttClient mClient = null;
        public List<string> topics = new List<string>();
        private static MQTTHandler instance = null;
     

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
            Console.WriteLine(Encoding.UTF8.GetString(e.Message));



            if (data[0].Equals("clean_data"))
            {
            }
        }

     
    }
}