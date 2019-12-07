using System;
using System.Data.SQLite;

namespace S2Lobby
{
    public class Database : IDisposable
    {
        public readonly SQLiteConnection Connection;

        public Database()
        {
            string connectionString = "Data Source=accounts.sqlite;";
            Connection = new SQLiteConnection(connectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
