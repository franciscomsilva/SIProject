using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DSA
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SQLAssistant sql = new SQLAssistant();

            List<User> users = sql.GetAllUsers();
            Console.WriteLine($"Li o user{users[0].Name} com o id {users[0].Id}");
        }
    }
}
