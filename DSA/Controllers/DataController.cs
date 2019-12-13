using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Controllers
{
    class DataController
    {
        static string connectionString = Properties.Resources.BDConnectString;

        private DataController()
        {
        }
        private static DataController instance = null;
        public static DataController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataController();
                }
                return instance;

            }
        }
        public void BootUpDataShow()
        {
            //TODO necessita de todos os sensores e locations
        }
        public Dictionary<string,string> MapCleanData(string sensor_id, string location_id)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            for (int i = 0; i < 2; i++)
            {

            }
            return null;

        }
    }
}
