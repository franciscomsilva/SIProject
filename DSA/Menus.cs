using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    class Menus
    {
        public void LoginMenu()
        {
            string user_id;
            string password;
            Console.Clear();
            Console.WriteLine("\n\n****************************************Welcome*********************************************\n");
            Console.WriteLine("Before you enter our service we'll need you to login!");
            Console.WriteLine("Insert your user ID: "); user_id = Console.ReadLine();
            Console.WriteLine("Insert the password: "); password = Console.ReadLine();
            //TODO:Verificação de input;
        }
    }
}
