using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Classes
{
    internal class Server
    {
        public string Name { get; set; }
        public string Server_id { get; set; }
        public
            string Password { get; set; }

        public Server() { }
        public Server(string name, string id, string password)
        {
            this.Name = name;
            this.Server_id = id;
            this.Password = password;
        }
    }
}
