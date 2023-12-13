using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Oracle.ManagedDataAccess.Client;

namespace RestaurantManager.Classes
{
    internal class Database
    {
        private string connectionString = "User Id=your_username;Password=your_password;Data Source=your_datasource;"; //insert connection details here;
        private string query = ""; // insert queries here;
        public List<Reservation> reservations = new List<Reservation>();


        public void ReadDatabase()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    this.FillLists(command);
                }
            }
        }

        public void FillLists(OracleCommand command) 
        {
            using (OracleDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Column1"]}, {reader["Column2"]}, {reader["Column3"]}");

                    // Replace Column1, Column2, Column3 with actual column names from your table.
                }
            }
        }
    }
}
