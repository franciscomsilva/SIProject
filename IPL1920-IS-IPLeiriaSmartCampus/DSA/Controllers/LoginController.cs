using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DSA.Controllers
{
    class LoginController
    {
        private LoginController()
        {
        }
        private static LoginController instance = null;
   
        public static LoginController Instance
        { get {
                if (instance == null)
                {
                    instance = new LoginController();
                }
                return instance;
            }
        }
        public string[] LoginAlerts(string name, string password)
        {
            string[] result = new string[2];
            string passwordDB = null;
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_users WHERE name=@name", sql);
                command.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    passwordDB = Convert.ToBase64String((byte[])reader["password"]);

                    if (password.Equals(passwordDB))
                    {
                        result[0] = (string)reader["id"].ToString();
                        result[1] = (string)reader["token"];
                    }
                    else
                    {
                        result[0] = "0";
                        result[1] = "00000";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool isLogged { get; set; }
        public int LoggedId { get; set; }
        static string connectionString = Properties.Resources.BDConnectString;
        public void Logout()
        {
            this.isLogged = false;
            this.LoggedId = -1;
            Console.WriteLine("Sucessfully Logged out!");
        }
        public bool Login(int index, string password)
        {
            string passwordDB=null;

            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_users WHERE id=@id", sql);
                command.Parameters.AddWithValue("@id", index);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    passwordDB = Convert.ToBase64String((byte[])reader["password"]);
                }
                using (SHA256 sha =SHA256.Create())
                {

                    byte[] hashedpassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));//hasha password for comparing
                    string p1 = Convert.ToBase64String(hashedpassword);
                  
             

                    if (p1.Equals(passwordDB)) 

                    {
                       this.isLogged = true;
                        this.LoggedId = index;
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error logging in! Reason: " + e.Message);
                return false;
            }

        }
    }
}
