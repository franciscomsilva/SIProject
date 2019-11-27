using DSA.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            UserController sqlUser = new UserController();
            SQLAssistant sqlAss = new SQLAssistant();

            sqlAss.cleanTable("t_users");
        }
    }
}
