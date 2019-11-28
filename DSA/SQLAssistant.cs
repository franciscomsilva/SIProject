﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Security.Cryptography;
namespace DSA
{

    class SQLAssistant
    {
        static string connectionString = Properties.Resources.BDConnectString;
        public void cleanTable(string table_name)
        {
            
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

    }
}