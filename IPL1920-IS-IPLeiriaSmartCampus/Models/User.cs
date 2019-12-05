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
        public User(string name, string password)
        {
            this.Id = -1;
            this.Name = name;
            this.Password = password;
        }
        public User(int id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }
        public User()
        {

        }
        public User(int id, string name, string password, bool isAdmin)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }
    }
}
