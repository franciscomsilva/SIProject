using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ALERTS_APPLICATION.Controller
{
    class LoginController
    {

        private static LoginController instance = null;
        private static string FILE_PATH = "user.config";
        private LoginController()

        {

        }


        public static LoginController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginController();
                }
                return instance;

            }
        }

        public void login(string username,string password)
        {
            string hashedBase64 = null;
            /*ENCRYPTS PASSWORD*/
            using (SHA256 sha = SHA256.Create())
            {

                byte[] hashedpassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));//hasha password for comparing
                hashedBase64 = Convert.ToBase64String(hashedpassword);
            }


            MQTTHandler.Instance.login(username, hashedBase64);

            saveUserID(MQTTHandler.Instance.UserID);

        }

        public int saveUserID(int userID)
        {
            try
            {

                File.WriteAllText(FILE_PATH, userID.ToString());

                Console.WriteLine("SAVED_USERID_FILE => " );

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR_SAVING_USERID_FILE => " + ex.Message);
            }



            return 0;
        }


        public int checkUserLogin()
        {
            try
            {

                if (!File.Exists(FILE_PATH))
                {
                    return -1;
                }

                string userID = File.ReadAllText(FILE_PATH);

                Console.WriteLine("READ_USERID_FILE => ");


                return int.Parse(userID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR_READING_USERID_FILE => " + ex.Message);

            }
            return -1;
         
        }


    }
}

