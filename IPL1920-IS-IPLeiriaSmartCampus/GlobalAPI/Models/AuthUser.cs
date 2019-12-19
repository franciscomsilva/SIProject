using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GlobalAPI.Models
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static AuthUser GetByToken(string token)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.DB))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT id, name FROM t_users WHERE token = @token", conn);
                cmd.Parameters.AddWithValue("@token", token);

                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;

                return new AuthUser()
                {
                    Id = (int) reader["id"],
                    Name = (string) reader["name"],
                };
            }
        }
    }
}