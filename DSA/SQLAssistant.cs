using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Security.Cryptography;
using DSA.Controllers;

namespace DSA
{

    class SQLAssistant
    {
        static string connectionString = Properties.Resources.BDConnectString;
        SQLAssistant()
        {
        }
        private static SQLAssistant instance = null;
        
        public static SQLAssistant Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLAssistant();
                }
                return instance;
            }
        }
        public bool isAdmin()
        {
            if (UserController.Instance.GetUser(LoginController.Instance.LoggedId).IsAdmin)
            {
                return true;
            }
   
                return false;
        }
        
        public void cleanTable(string table_name)
        {
            //TODO: Admin perms only

            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM "+table_name, sql);
       
                sqlCommand.ExecuteNonQuery();
                
                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error cleaning {table_name}! Reason: " + e.Message);
            }
        }
        public void reseedTable(string table_name)
        {
            cleanTable(table_name); 

            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand($"DBCC CHECKIDENT ('{table_name}', RESEED, 0)", sql);

                sqlCommand.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error reseting {table_name}! Reason: " + e.Message);
            }
        }

    }
}
