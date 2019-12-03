using DSA.Controllers;
using DSA.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

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
        MqttClient mClient = null;
        string[] topics = {  };
        byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
   

        public void ConnectAndSubscribe()
        {
            int i,j;
            List<String> sensorsReadings;
            for (i = 0; i < SensorController.Instance.GetAllSensors().Count ; i++) //todos os canais de raw data
            {
                sensorsReadings = SensorController.Instance.GetSensorReadingTypes(i);
                foreach (string reading in sensorsReadings)
                {
                    topics[i] = $"sensor_data/{i}/{reading}";
                }
            }
            for (j = i; j < AlertController.Instance.GetAllAlerts().Count+i; i++)
            {
                topics[j] = $"alerts_data/{j - i}";
            }
            topics[j++] = $"alerts/new_alert";
            Console.WriteLine(topics.ToString());
            if (mClient!=null && mClient.IsConnected )
            {
                Console.WriteLine("Mqtt was connected to the broker already!");
            }
            Console.WriteLine("Connecting...");
            mClient = new MqttClient("127.0.0.1");
            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error Connecting to Message Broker!");
                return;
            }
            mClient.MqttMsgPublishReceived += MClient_MqttMsgPublishReceived;
            mClient.Subscribe(topics, qosLevels);
        }

        private void MClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
           Console.WriteLine($"Received = {Encoding.UTF8.GetString(e.Message)} on topic = {e.Topic} {Environment.NewLine}");
        }
    }
}
