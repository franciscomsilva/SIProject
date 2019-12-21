using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALERTS_APPLICATION.Controller
{
    class ParameterController
    {
        private static ParameterController instance = null;

        private ParameterController() { 
            


        }

        public static ParameterController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ParameterController();
                }
                return instance;
            }
        }


    }
}
