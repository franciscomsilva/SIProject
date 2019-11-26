using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DSA
{

    class SQLAssistant
    {
        static string connectionString = Properties.Resources.BDConnectString;
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("Select * from t_users", sql);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"]
                    };
                    users.Add(user);
                };
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong!" + e.Message);
                Console.ReadKey();
            }


            return users;
        }
    }
}
