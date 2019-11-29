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

        public bool isLogged { get; set; }
        public int LoggedId { get; set; }
        static string connectionString = Properties.Resources.BDConnectString;

        public void Login(int index, string password)
        {
            string passwordDB=null;
            //TODO: implementar login, altera os isLogged e isso vai ser a var que controla o login, aquando do logout ela e set to false again, added campo a BD chamado 
            //isAdmin para apoiar a Api e permitir operações mais sensíves deste lado
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
                        Console.WriteLine("Login was sucessfull!");
                    }
                    else
                    {
                        Console.WriteLine("Login failed, consider reentering the password");
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error logging in! Reason: " + e.Message);
            }

        }
    }
}
