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

            Console.WriteLine(DateTime.Today.ToShortDateString() );
        }
    }
}
