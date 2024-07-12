using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management
{
    public class Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Entity(string username,string password)
        {
            Username = username;
            Password = password;
        }
    }
}
