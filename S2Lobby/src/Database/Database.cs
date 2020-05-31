using System;
using System.Data.SQLite;
using MySql.Data.MySqlClient;


namespace S2Lobby
{
    public class Database : IDisposable
    {
        public readonly MySqlConnection Connection;

        public Database(Program program)
        {
            string connectionString =
           "Server=" + Config.Get("database/mysql/ip") + ";" +
           "Port=" + Config.Get("database/mysql/port") + ";" +
           "Database=" + Config.Get("database/mysql/name") + ";" +
           "User ID=" + Config.Get("database/mysql/user") + ";" +
           "Password=" + Config.Get("database/mysql/pass") + ";" +
           "Pooling=true";

            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
