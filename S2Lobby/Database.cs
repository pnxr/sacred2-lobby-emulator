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
           "Server=" + program.DbIp + ";" +
           "Port=" + program.DbPort + ";" +
           "Database=" + program.DbName + ";" +
           "User ID=" + program.DbUser + ";" +
           "Password=" + program.DbPass + ";" +
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
