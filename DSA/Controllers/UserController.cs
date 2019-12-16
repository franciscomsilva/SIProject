using Models;
using Newtonsoft.Json;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DSA.Controllers
{
    class UserController
    {
        private UserController(){
            }
        private readonly int tokenLength = 64;
        private static UserController instance = null;
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static UserController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserController();
                }
                return instance;
            }
        }
        static string connectionString = Properties.Resources.BDConnectString;

        public User GetUser(int index)
        {
            User user = null;
            if (index<=0)
            {
                Console.WriteLine("Index needs to be positive!");
                return user;
            }
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_users WHERE id=@id", sql);
                command.Parameters.AddWithValue("@id", index);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Password = Encoding.UTF8.GetString((byte[])reader["password"]),
                        IsAdmin = (bool)reader["isAdmin"]
                    };
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error retrieving user! Reason: " + e.Message);
            }

            return user;
        }

        public List<User> GetAllUsers()
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
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Password = Encoding.UTF8.GetString((byte[])reader["password"])

                    };
                    users.Add(user);
                };
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Failed retrieving user list! Reason:" + e.Message);
                Console.ReadKey();
                return null;
            }


            return users;
        }
        public string GetUserToken(string token)
        {
            string userId = "-1";
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM t_users WHERE token=@token", sql);
                command.Parameters.AddWithValue("@token", token);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userId = (string)reader["id"].ToString();  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving user! Reason: " + e.Message);
            }
            return userId;
        }
        public void AddUser(User user)
        {
            Console.WriteLine(user.Password);
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO t_users VALUES(@name,0,@password,@token)", sql);
                sqlCommand.Parameters.AddWithValue("@name", user.Name);
                sqlCommand.Parameters.AddWithValue("@token", generateUserToken()); 
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] hashedPassword =sha.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                    Console.WriteLine("Hash: "+ hashedPassword.ToString());
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
        public string generateUserToken()
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder(tokenLength);
            for (int i = 0; i < tokenLength; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            Console.WriteLine("");
            return result.ToString();
        }
    }

    }













