using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ALERTS_APPLICATION
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
        private MqttClient mClient = null;
        public List<string> topics = new List<string>();


        public void ConnectAndSubscribe()
        {
            if (mClient != null && mClient.IsConnected)
            {
                Console.WriteLine("ERROR_CONNECTION_EXISTED");
                return;
            }

            if (mClient != null && mClient.IsConnected)
            {
                Console.WriteLine("ERROR_CONNECTION_BROKER_EXISTED");
            }
            Console.WriteLine("CONNECTING TO BROKER...");
            mClient = new MqttClient("127.0.0.1");

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("ERROR_CONNECTING_BROKER!");
                return;
            }
            for (int h = 0; h < topics.Count; h++)
            {
                Console.WriteLine("Connecting to topic number " + h + ":" + topics[h]);
                mClient.Subscribe(new string[] { topics[h] }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
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
            //Acerca desta função: Nós vamos ter de separar os dados incoming apropriadamente para poderem ser parsed pelo controlador apropriado e reenviados para clean data, ou para poder
            //realizar operações non-sensor data related(IE ajudar o boot do alerts etc)
            string[] topics = e.Topic.Split('/');
            Console.WriteLine(Encoding.UTF8.GetString(e.Message));
            //----------------------------------------DADOS DE SENSORES----------------------------------------------------------//
            if (topics[0].Equals("sensor_data"))
            {

            }
            //---------------------------------------Bootup alerts--------------------------------------------------------------//
            if (topics[0].Equals("alerts"))
            {
                if (Encoding.UTF8.GetString(e.Message).Equals("Request"))
                {
                    List<string> readingTypes = SensorController.Instance.getAllReadingTypes();
                    publishData("alerts/readingType", JsonConvert.SerializeObject(readingTypes.ToArray()));
                }

            }
            //----------------------------------------------Dados de alerts------------------------------------------------------//
            if (topics[0].Equals("alerts_data"))
            {

            }

        }
    }
}