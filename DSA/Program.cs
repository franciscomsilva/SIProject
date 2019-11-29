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
            UserController sqlUser = new UserController();
            SQLAssistant sqlAss = new SQLAssistant();
            LocationController sqlLocation = new LocationController();
            LoginController sqlLogin = new LoginController();
           //sqlAss.cleanTable("t_users");
           // sqlUser.AddUser(new User("TesteLogin", "123"));
            sqlLogin.Login(1035, "123");
            Console.WriteLine("Login com sucesso?: " + sqlLogin.isLogged + "\n" + "Id do user loggado :" + sqlLogin.LoggedId);
            sqlLogin.Logout();
            Console.WriteLine("Login com sucesso?: " + sqlLogin.isLogged + "\n" + "Id do user loggado :" + sqlLogin.LoggedId);
        }
    }
}
