using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Classes
{
    public class Reservation
    {
        public string ReservationCode { get; set; }
        public string CustomerName { get; set; }
        public string ReservationTime { get; set; }
        public string GuestAmount { get; set; }
        public string ServerName { get; set; }
        public string TableNumber { get; set; }
        public string Status { get; set; }

        public Reservation(string code, string customer, string time, string guests, string server, string table, string status)
        {
            this.ReservationCode = code;
            this.CustomerName = customer;
            this.ReservationTime = time;
            this.GuestAmount = guests;
            this.ServerName = server;
            this.TableNumber = table;
            this.Status = status;
        }

    }
}
