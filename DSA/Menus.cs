using DSA.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

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
            Console.WriteLine("Hello there "+UserController.Instance.GetUser(LoginController.Instance.LoggedId).Name+" what do you wish to do today?");
            Console.WriteLine("\tChoose an option: ");
            Console.WriteLine("\t\t(1)User Operations");
            Console.WriteLine("\t\t(2)Sensor Operations");
            Console.WriteLine("\t\t(3)Connect MQTT Service");
            Console.WriteLine("\t\t(4)Logout)");
            Console.WriteLine("\t\t(5)Exit application");
            key=Console.ReadKey().KeyChar;Console.WriteLine();
            switch (key){
                case '1': UserMenu();  break;
                case '2':SensorMenu(); break;
                case '3': MQTTHandler.Instance.ConnectAndSubscribe();break;
                case '4': LoginController.Instance.Logout();return;
                case '5': Console.WriteLine("Exiting as by user request");System.Environment.Exit(0);break;
                default: Console.WriteLine("Invalid option, please choose again!");break;

            }
      
        }
        public void UserMenu()
        {
 
            Console.Clear();
            Console.WriteLine("\n****************************************User Menu*********************************************");
            Console.WriteLine("\tChoose an option: ");
            Console.WriteLine("\t(1)Add a new User");
            Console.WriteLine("\t(2)Back to the main menu");
            char key = Console.ReadKey().KeyChar;Console.WriteLine();
            switch (key)
            {
                case '1':Console.WriteLine("Username:");
                  string username =  Console.ReadLine();
                    Console.Write("Password:");
                    ConsoleColor origBG = Console.BackgroundColor; 
                    ConsoleColor origFG = Console.ForegroundColor;

                    Console.BackgroundColor = ConsoleColor.Black; 
                    Console.ForegroundColor = ConsoleColor.Black;

                    string password = Console.ReadLine();
                    Console.Clear();
                    Console.BackgroundColor = origBG; 
                    Console.ForegroundColor = origFG;
                    UserController.Instance.AddUser(new User(username, password));
                    break;

                case '2':return;
            }

            Console.ReadLine();
        }
        public void SensorMenu()
        {
            Console.Clear();
            Console.WriteLine("\n****************************************Sensor Menu*********************************************");
            Console.WriteLine("\tChoose an option: ");
            Console.WriteLine("\t(1)Add a new Sensor");
            Console.WriteLine("\t(2)Back to the main menu");
            char key = Console.ReadKey().KeyChar; Console.WriteLine();
            switch (key)
            {
                case '1':addSensorMenu(); break;
                case '2':return;   
            }
        }
        public void  addSensorMenu()
        {
            int sensor_id;
            int location_id = -1; 
            Console.WriteLine("Where is the sensor?");
           string locationName= Console.ReadLine();
            if (String.IsNullOrWhiteSpace(locationName))
            {
                while (true)
                {
                    Console.WriteLine("Insert location name: ");
                    locationName = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(locationName))
                    {
                        break;
                    }
                }
            }
            location_id = LocationController.Instance.CheckIfLocationExists(locationName);
            int keyValue;
            char key;
            while (true) {
                Console.WriteLine("How many types of data can the sensor read?");
                 key = Console.ReadKey().KeyChar;
                if (!int.TryParse(key.ToString(), out keyValue))
                {
                    Console.WriteLine("You need to insert a valid number! Example : 2");
                }
                else
                {
                    break;
                }
            }
            //------------------------------TEM DE SE CRIAR O SENSOR ANTES DOS READINGS, CAUSE CONSTRAINTS----------------------------//
            SensorController.Instance.AddSensor(location_id);
            sensor_id = SensorController.Instance.GetAllSensors()[SensorController.Instance.GetAllSensors().Count-1].Id; //Ultimo da lista
            //-----------------------------------------------------------------------------------------------------------------------//
            string measure_name, measure_type, min_value, max_value;
            List<string> listaTypes = new List<string>();
            bool control = false;
            for (int i = 0; i < keyValue; i++)
            {
                Console.WriteLine("Ok, now we'll need you to insert the reading type data!");
                Console.Write("Insert Measure Name(Ex:Humidity): ");
                measure_name=Console.ReadLine();
                //--VERIFICAR SE LEITURA E UNIQUE AO SENSOR
                if (listaTypes.Count!=0)
                {
                    if (listaTypes.Contains(measure_name.ToLower()))
                    {
                        Console.WriteLine("A measure with this name already exists, do you want to re-enter the value(1) or skip(2)?");
                        key = Console.ReadKey().KeyChar;
                        switch (key)
                        {
                            case '1': i--; continue; 
                            case '2': continue;
                        }

                    }
                }
                else{
                    listaTypes.Add(measure_name.ToLower());
                }
                    
                //---------
                while (true)
                {
                    Console.Write("\nInsert Measure Type(Float,Int,Bool,String): ");
                    measure_type = Console.ReadLine();
                    switch (measure_type.ToUpper())
                    {
                        case "FLOAT":measure_type = "float"; control = true; break;
                        case "INT":measure_type = "int"; control = true; break;
                        case "BOOL":measure_type = "bool"; control = true; break;
                        case "STRING":measure_type = "string"; control = true; break;
                        default:Console.WriteLine("Measure type needs to be of one of the specified types!");break;
                    }
                    if (control)
                    {
                        break;
                    }
                }
                Console.Write("Insert minimum value for this reading, leave blank if none: ");
                min_value=Console.ReadLine(); 
                Console.Write("Insert max value for this reading, leave blank if none: ");
                max_value=Console.ReadLine();

                if (string.IsNullOrWhiteSpace(min_value))
                {
                    min_value = null;
                }
                if (string.IsNullOrWhiteSpace(max_value))
                {
                    max_value = null;
                }
                SensorController.Instance.addReadingType(measure_name, measure_type, sensor_id, min_value, max_value);
            }
        }
    }
}
