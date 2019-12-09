using DSA.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using Newtonsoft.Json;
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
        List<string> topics = new List<string>();
   

        public void ConnectAndSubscribe()
        {
            if (mClient!=null &&  mClient.IsConnected)
            {
                Console.WriteLine("You're already connected, hurray!");
                return;
            }
            List<String> sensorsReadings;
            topics.Add("alerts/readingType");
            foreach (Sensor sensor in SensorController.Instance.GetAllSensors()) //todos os canais de raw data
            {
                sensorsReadings = SensorController.Instance.GetSensorReadingTypes(sensor.Id);
                foreach (string reading in sensorsReadings)
                {
                    topics.Add( $"sensor_data/{sensor.Id}/{reading}");
                }
            }
            foreach(Alert alert in AlertController.Instance.GetAllAlerts())
                topics.Add ($"alerts_data/{ alert.Id }");
            

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
            for (int h = 0; h < topics.Count; h++)
            {
                Console.WriteLine("Connecting to topic number "+h+":"+topics[h]);
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
            Console.WriteLine(Encoding.UTF8.GetString(e.Message));
            //----------------------------------------DADOS DE SENSORES----------------------------------------------------------//
            if (topics[0].Equals("sensor_data"))
            {
                SensorController.Instance.insertSensorData(int.Parse(topics[1]), topics[2],Encoding.UTF8.GetString(e.Message));
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
