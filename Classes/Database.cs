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
        private readonly string connectionString = "User Id=cprg250;Password=password;Data Source=//Ai:1521/XE;"; //insert connection details here;

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
            OracleDataReader reader = this.QueryDatabase("SELECT * FROM rm_reservation");
            List<Reservation> reservations = new List<Reservation>();

            string code;
            string customer;
            DateTime time;
            int guests;
            string serverID;
            int table;
            string status;

            while (reader.Read())
            {
                code = (string)reader["column1"];
                customer  = (string)reader["column2"];
                time = (DateTime)reader["column3"];
                guests = (int)reader["column4"];
                serverID = (string)reader["column5"];
                table = (int)reader["column6"];
                status = (string)reader["column7"];

                reservations.Add(new Reservation(code, customer, time, guests, serverID, table, status));
            }
            return reservations;
        }

        public List<Server> FetchServers()
        {
            OracleDataReader reader = this.QueryDatabase("SELECT * FROM rm_server");
            List<Server> servers = new List<Server>();

            string server;
            string serverID;
            string password;

            while (reader.Read())
            {
                server = (string)reader["name_server"];
                serverID = (string)reader["id"];
                password = (string)reader["password"];

                servers.Add(new Server(server, serverID, password));
            }
            return servers;
        }

        public List<int> FetchTables()
        {
            OracleDataReader reader = this.QueryDatabase("SELECT * FROM rm_table");
            List<int> tables = new List<int>();

            int table;

            while (reader.Read())
            {
                table = (int)reader["table_num"];
                tables.Add(table);
            }

            return tables;
        }
    }
}
