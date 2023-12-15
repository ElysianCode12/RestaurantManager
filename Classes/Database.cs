using System;
using System.Collections;
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
    public class Database
    {
        private readonly string connectionString = "User Id=cprg250;Password=password;Data Source=//DESKTOP-1TM11PF:1521/XE;"; //insert connection details here;

        public List<int> FetchTables()
        {
            List<int> tables = new List<int>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT * FROM rm_table", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Data from the table:");

                        while (reader.Read())
                        {
                            tables.Add(reader.GetInt16(0));
                        }
                        return tables;
                    }
                }
            }
        }

        public List<Server> FetchServers()
        {
            List<Server> servers = new List<Server>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT * FROM rm_server", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Data from the table:");

                        while (reader.Read())
                        {
                            servers.Add(new Server(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                        }
                        return servers;
                    }
                }
            }
        }

        public List<Reservation> FetchReservations() 
        {
            List<Reservation> reservations = new List<Reservation>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT * FROM rm_reservation", connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Data from the table:");

                        while (reader.Read())
                        {
                            reservations.Add(new Reservation(
                                reader.GetString(0), //reservation code
                                reader.GetString(1), //customer name
                                reader.GetDateTime(2), //reservation date & time
                                reader.GetInt16(3), //amount of guests
                                reader.GetString(4), //serverID
                                reader.GetInt16(5), //table number
                                reader.GetString(6) //reservation status
                                ));
                        }
                        return reservations;
                    }
                }
            }
        }

        public void AddReservation(Reservation reservation)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                // Insert reservation data into rm_reservation table
                string insertQuery = $"INSERT INTO rm_reservation VALUES (" +
                    $"{reservation.ReservationCode}," +
                    $"{reservation.CustomerName}, " +
                    $"{reservation.ReservationTime}, " +
                    $"{reservation.GuestAmount}," +
                    $"{reservation.ServerID}," +
                    $"{reservation.TableNumber}," +
                    $"{reservation.Status})"; 

                using (OracleCommand command = new OracleCommand(insertQuery, connection))
                {
                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
