using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DataShowApplication;
using Models;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DataShowApplication
{
    class MQTTHandler
    {
        private MqttClient mClient = null;
        public List<string> topics = new List<string>();
        private static MQTTHandler instance = null;

        public List<ReadingType> ReadingTypes { get; set; }
        public List<Alert> Alerts { get; set; }

        private MQTTHandler()
        {
            //clean_data/<sensor_id>/<reading_type>
            topics.Add("clean_data/1/1");
            //alerts_data/<alert_id>
            topics.Add("alerts_data/1");

            topics.Add("dataShow/start");

            ConnectAndSubscribe();

            publishData("dataShow/start", "request");
        }
        public static MQTTHandler Instance {
            get {
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
            string message = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine(message);
            string[] information = null;

            if (data[0].Equals("dataShow"))
            {
                //RECEIVE: List<Alert>/List<Sensor>/List<ReadingTypes>/List<Users>
                information = message.Split('§');

                if (message.ToLower().Equals("request")) return;

                //unsubscribe the topic 
                unsubscribe(new string[] { "dataShow/start" });

                Console.WriteLine("Adding initial data");

                // Add the locations
                List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(information[0]);

                //Add the ReadingTypes
                AppData.Instance.SetReadingTypes(JsonConvert.DeserializeObject<List<ReadingType>>(information[1]));

                //Add the Sensors
                List<Sensor> sensors = JsonConvert.DeserializeObject<List<Sensor>>(information[2]);
                foreach (Sensor sensor in sensors)
                {
                    AppData.Instance.AddSensor(sensor);
                }

                //Add the alerts
                AppData.Instance.SetAlerts(JsonConvert.DeserializeObject<List<Alert>>(information[3]));

            }

            if (data[0].Equals("clean_data"))
            {
                sensorID = int.Parse(data[1]);

                SensorData sensorData = JsonConvert.DeserializeObject<SensorData>(Encoding.UTF8.GetString(e.Message));
                AppData.Instance.SaveSensorValues(sensorData);

                sensorID = 0;
            }

            if (data[0].Equals("alerts_data"))
            {
                //RECEIVE ALERTS ??????????????
                Alerts = JsonConvert.DeserializeObject<List<Alert>>(Encoding.UTF8.GetString(e.Message));
                //AppData.Instance.AddAlert();
            }
        }
        public void sendRequest()
        {
            publishData("dataShow/start", "request");
        }

        public void unsubscribe(string[] topic)
        {
            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topic);
            }
        }
    }
}