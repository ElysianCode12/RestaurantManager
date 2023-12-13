using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Classes
{
    public class Server
    {
        string Name { get; set; }
        string Server_id { get; set; }
        string Password { get; set; }

        public Server(string name, string id, string password)
        {
            this.Name = name;
            this.Server_id = id;
            this.Password = password;
        }
    }
}
