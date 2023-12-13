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
        public DateTime ReservationTime { get; set; }
        public int GuestAmount { get; set; }
        public string ServerID { get; set; }
        public int TableNumber { get; set; }
        public string Status { get; set; }

        public Reservation(string code, string customer, DateTime time, int guests, string serverID, int table, string status)
        {
            this.ReservationCode = code;
            this.CustomerName = customer;
            this.ReservationTime = time;
            this.GuestAmount = guests;
            this.ServerID = serverID;
            this.TableNumber = table;
            this.Status = status;
        }

    }
}
