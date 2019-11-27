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

            User user = sqlUser.GetUser(30);
            if (user==null)
            {
                Console.WriteLine("User não encontrado");
            }
            Console.WriteLine(user);
        }
    }
}
