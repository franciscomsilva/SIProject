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
            UserController sqlUser = UserController.Instance;
            SQLAssistant sqlAss = SQLAssistant.Instance;
            LocationController sqlLocation = LocationController.Instance;
            LoginController sqlLogin = LoginController.Instance;
            Menus menu = new Menus();
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
