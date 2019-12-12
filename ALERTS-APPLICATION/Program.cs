using ALERTS_APPLICATION.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALERTS_APPLICATION
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

         /*   if(LoginController.Instance.checkUserLogin() != -1)
            {
                Application.Run(new Main());
                return;
            }*/

            Application.Run(new Main());
        }
    }
}
