using DSA.Controllers;
using System;
using DSA.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;

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
             LocationController.Instance.AddLocation("Biblioteca");
            UserController.Instance.AddUser(new User("Teste User ", "123"));
            Console.WriteLine(JsonConvert.SerializeObject(UserController.Instance.GetAllUsers()));

             /*    while (true)
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

                    */
                
        }
    }
}
