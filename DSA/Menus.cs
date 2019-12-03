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
        
            string user_id;
            string password;
            Console.Clear();
            Console.WriteLine("\n\n****************************************Welcome*********************************************\n");
            Console.WriteLine("Before you enter our service we'll need you to login!");
            Console.Write("\tInsert your user ID: "); user_id = Console.ReadLine();
            Console.Write("\tInsert the password: "); password = Console.ReadLine();
            
            while (true) {
                if (i != 0)
                {
                    Console.Write("Insert your user ID: "); user_id = Console.ReadLine();
             
                    Console.Write("Insert the password: "); password = Console.ReadLine();

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
                if (n < 1)
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
            char key;
            Console.WriteLine("\n****************************************Main Menu*********************************************");
            Console.WriteLine("Hello there "+UserController.Instance.GetUser(LoginController.Instance.LoggedId).name+" what do you wish to do today?");
            Console.WriteLine("\tChoose an option: ");
            Console.WriteLine("\t\t(1)User Operations");
            Console.WriteLine("\t\t(2)Sensor Operations");
            Console.WriteLine("\t\t(3)Connect MQTT Service");
            Console.WriteLine("\t\t(4)Logout)");
            Console.WriteLine("\t\t(5)Exit application");
            key=Console.ReadKey().KeyChar;Console.WriteLine();
            switch (key){
                case '1': UserMenu();  break;
                case '2':break;
                case '3': MQTTHandler.Instance.ConnectAndSubscribe();break;
                case '4': LoginController.Instance.Logout();return;
                case '5': Console.WriteLine("Exiting as by user request");System.Environment.Exit(0);break;
                default: Console.WriteLine("Invalid option, please choose again!");break;

            }
      
        }
        public void UserMenu()
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("\n****************************************Main Menu*********************************************");
            Console.WriteLine("\tChoose an option: ");
            if (SQLAssistant.Instance.isAdmin()) // ver se e admin
            {
                Console.WriteLine($"(A)Adicionar Novo Utilizador");

            }

            Console.ReadLine();
        }
    }
}
