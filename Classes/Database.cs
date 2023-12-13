using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Oracle.ManagedDataAccess.Client;

namespace RestaurantManager.Classes
{
    internal class Database
    {
        private string connectionString = "User Id=your_username;Password=your_password;Data Source=your_datasource;"; //insert connection details here;

        public OracleConnection OpenDatabase()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                return connection;
            }
        }

        public OracleDataReader QueryDatabase(string query) 
        {
            OracleConnection connection = this.OpenDatabase();

            using (OracleCommand command = new OracleCommand(query, connection))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    return reader;
                }
            }
        }

        public List<Reservation> FetchReservations()
        {
            OracleDataReader reader = this.QueryDatabase("SELECT * FROM whatever the table name is");
            List<Reservation> reservations = new List<Reservation>();

            string code;
            string customer;
            string time;
            string guests;
            string server;
            string table;
            string status;

            while (reader.Read())
            {
                code = (string)reader["column1"];
                customer  = (string)reader["column2"];
                time = (string)reader["column3"];
                guests = (string)reader["column4"];
                server = (string)reader["column5"];
                table = (string)reader["column6"];
                status = (string)reader["column7"];

                reservations.Add(new Reservation(code, customer, time, guests, server, table, status));
            }

            return reservations;
        }
    }
}
