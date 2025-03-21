using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace JeuxList
{
    public class DatabaseConnection
    {
        string connectionString = "Server=localhost;Database=bibliothequejeux;User Id=root;Password=;";

        public DatabaseConnection()
        {
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        public void OpenConnection(MySqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
