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
        public int UserID { get; set; }
        public string UserTOKEN { get; set; }

        private LoginController()

        {
            this.UserID = -1;
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

        }

        public int saveUserIDToken(int userID,string token)
        {
            try
            {

                File.WriteAllText(FILE_PATH, token);

                this.UserID = userID;

                Console.WriteLine("SAVED_USERID");
                Console.WriteLine("SAVED_USERTOKEN_FILE ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR_SAVING_USERTOKEN_FILE => " + ex.Message);
            }



            return 0;
        }


        public int checkUserLogin()
        {

            return this.UserID;


        }


        public void checkTokenSaved()
        {
            if (File.Exists(FILE_PATH))
            {
                string token = File.ReadAllText(FILE_PATH);


                MQTTHandler.Instance.sendToken(token);
            }

        }


    }
}

