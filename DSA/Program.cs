using DSA.Controllers;
using System;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Instanciamento Singletons e Menus
            //Nota:A razão de instancionamento de singletons aqui é muito simples, não as proteji de multithreading, e program bootup so existe uma thread, aka, nunca instancia 2 vezes
            MQTTHandler mqtt = MQTTHandler.Instance;
            UserController sqlUser = UserController.Instance;
            SQLAssistant sqlAss = SQLAssistant.Instance;
            SensorController sqlSensor = SensorController.Instance;
            LocationController sqlLocation = LocationController.Instance;
            LoginController sqlLogin = LoginController.Instance;
            AlertController sqlAlert = AlertController.Instance;
            Menus menu = new Menus();
            DataController sqlData = DataController.Instance;
            #endregion


                  while (true)
                        {

                            if (sqlLogin.isLogged)
                            {

                       menu.MainMenu();
                            }
                            else
                            {

                           menu.LoginMenu();
                            }
                        } 

                   



        }
    }
}
