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
    }
}
