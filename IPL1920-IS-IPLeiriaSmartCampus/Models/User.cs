using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public User(string Username, string password)
        {
            this.Name = Username;
            this.Password = password;
        }
        public User(int id, string Username, string password,bool isAdmin)
        {
            this.Name = Username;
            this.Password = password;
            this.IsAdmin = isAdmin;
            this.Id = id;
        }
        public User()
        {

        }

    }
}
