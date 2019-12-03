using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DSA
{


    class User
    {

        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
        public User(string name, string password)
        {
            this.id = -1;
            this.name = name;
            this.password= password;
        }
        public User(int id,string name, string password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }
        public User()
        {

        }
        public User(int id, string name, string password,bool isAdmin)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.isAdmin = isAdmin;
        }

    }
}
