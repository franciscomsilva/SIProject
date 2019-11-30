using DSA.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    class Menus
    {
        public void LoginMenu()
        {
            int n,i=0;
            bool repeat = false;
            string user_id;
            string password;
            Console.Clear();
            Console.WriteLine("\n\n****************************************Welcome*********************************************\n");
            Console.WriteLine("Before you enter our service we'll need you to login!");
            Console.WriteLine("Insert your user ID: "); user_id = Console.ReadLine();
            Console.WriteLine("Insert the password: "); password = Console.ReadLine();
            //TODO:Verificação de input;
            while (true) {
                if (i != 0)
                {
                    Console.WriteLine("Insert your user ID: "); user_id = Console.ReadLine();
                    Console.WriteLine("Insert the password: "); password = Console.ReadLine();
                }
                if (String.IsNullOrEmpty(user_id) || String.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Cannot process empty fields, please reenter your ID and password.");
                    i++;
                    continue;
                }
                if (!int.TryParse(user_id, out n))
                {
                    Console.WriteLine("The user id needs to be a number!");
                    i++;
                    continue;
                }
                if (n <= 1)
                {
                    Console.WriteLine("The user id needs to be greater than 1!");
                    i++;
                    continue;
                }
                break;
            };
            if (LoginController.Instance.Login(n, password))
            {
                Console.WriteLine("Login successfull, welcome!");
                return;
            }
            else
            {
                Console.WriteLine("I'm sorry, no users match those credentials, try again!");
                Console.WriteLine("Click any key to continue!");
                Console.ReadKey();
                return;
            }
        }
        public void MainMenu()
        {
            Console.WriteLine("Tou");

        }
    }
}
