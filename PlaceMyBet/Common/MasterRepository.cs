using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace PlaceMyBet_1.Common
{
    public class MasterRepository
    {
        private static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet_v2;";
        private static bool connectionWorking;
        private static string errorProduced;
        private static List<ArrayList> dataRows;
        public static bool ConnectionWorking => connectionWorking;
        public static string ErrorProduced => errorProduced;
        public static List<ArrayList> DataRows => dataRows;

        public static List<ArrayList> Leer(string querySQL)
        {
            connectionWorking = true;
            errorProduced = "";

            dataRows = new List<ArrayList>();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querySQL, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    ArrayList data = new ArrayList();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        data.Add(reader[i]);
                    }
                    dataRows.Add(data);
                }
            }
            catch (MySqlException ex)
            {
                connectionWorking = false;
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    errorProduced = "No hay conexión con los servidores";
                else
                    errorProduced = ex.Message;
            }
            databaseConnection.Close();
            return dataRows;
        }

        public static List<ArrayList> Leer(MySqlCommand commandDatabase)
        {
            connectionWorking = true;
            errorProduced = "";
            dataRows = new List<ArrayList>();
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            commandDatabase.CommandTimeout = 60; 
            commandDatabase.Connection = databaseConnection;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    ArrayList data = new ArrayList();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        data.Add(reader[i]);
                    }
                    dataRows.Add(data);
                }
            }
            catch (MySqlException ex)
            {
                connectionWorking = false;
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    errorProduced = "No hay conexión con los servidores";
                else
                    errorProduced = ex.Message;
            }
            databaseConnection.Close();
            return dataRows;
        }

        public static bool Escribir(MySqlCommand commandDatabase)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            commandDatabase.CommandTimeout = 60;
            commandDatabase.Connection = databaseConnection;

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Escribir(string querySQL)
        {
            using (MySqlConnection databaseConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand commandDatabase = new MySqlCommand(querySQL, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}