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
        private readonly string connectionString = "User Id=user;Password=password;Data Source=//hostname:1521/XE;"; //insert connection details here;

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

                // Use parameterized query to avoid SQL injection
                string insertQuery = "INSERT INTO rm_reservation " +
                    "(reservation_code, name_customer, time, num_guest, id, table_num, status) " +
                    "VALUES " +
                    "(:reservationCode, :nameCustomer, :reservationTime, :numGuest, :serverId, :tableNumber, :reservationStatus)";

                using (OracleCommand command = new OracleCommand(insertQuery, connection))
                {
                    // Add parameters
                    command.Parameters.Add("reservationCode", OracleDbType.Varchar2).Value = reservation.ReservationCode;
                    command.Parameters.Add("nameCustomer", OracleDbType.Varchar2).Value = reservation.CustomerName;
                    command.Parameters.Add("reservationTime", OracleDbType.TimeStamp).Value = reservation.ReservationTime;
                    command.Parameters.Add("numGuest", OracleDbType.Int32).Value = reservation.GuestAmount;
                    command.Parameters.Add("serverId", OracleDbType.Varchar2).Value = reservation.ServerID;
                    command.Parameters.Add("tableNumber", OracleDbType.Int32).Value = reservation.TableNumber;
                    command.Parameters.Add("reservationStatus", OracleDbType.Varchar2).Value = reservation.Status;

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateReservationStatus(string reservationCode, string newStatus)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string query = "UPDATE rm_reservation SET status = :newStatus WHERE reservation_code = :reservationCode";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.Add(":newStatus", OracleDbType.Varchar2).Value = newStatus;
                    command.Parameters.Add(":reservationCode", OracleDbType.Varchar2).Value = reservationCode;

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
