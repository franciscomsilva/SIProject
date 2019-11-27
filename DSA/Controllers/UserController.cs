using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DSA.Controllers
{
    class UserController
    {
        static string connectionString = Properties.Resources.BDConnectString;
        public User GetUser(int index)
        {
            User user=null;
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM t_users WHERE id=@id");
            command.Parameters.AddWithValue("@id",index);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = new User
                {
                    id =(int)reader["id"],
                    name=(string)reader["name"]
                };
            }

            return user;
        }

        public string GetAllUsers()
        {
            
            List<User> users = new List<User>();
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM t_users", sql);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        id = (int)reader["id"],
                        name = (string)reader["name"],
                        password = Encoding.UTF8.GetString((byte[])reader["password"])
                    };
                    users.Add(user);
                };
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed retrieving user list! Reason:" + e.Message);
                Console.ReadKey();
            }


            return JsonConvert.SerializeObject(users);
        }
        public void AddUser(User user)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_users VALUES(@name,@password)", sql);
                sqlCommand.Parameters.AddWithValue("@name", user.name);
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] hashedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                    sqlCommand.Parameters.AddWithValue("@password", hashedPassword);
                }
                sqlCommand.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed creating a new user! Reason:" + e.Message);
                Console.ReadKey();
            }
        }

    }
}
