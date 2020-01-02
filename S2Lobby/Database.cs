using System;
using System.Data.SQLite;

namespace S2Lobby
{
    public class Database : IDisposable
    {
        public readonly SQLiteConnection Connection;

        private SQLiteConnection _channelDB;

        public SQLiteConnection Channels
        {
            get
            {
                if (_channelDB == null)
                {
                    string connectionString = "Data Source=channels.sqlite;";
                    _channelDB = new SQLiteConnection(connectionString);
                    _channelDB.Open();
                }
                return _channelDB;
            }
        }

        public Database()
        {
            string connectionString = "Data Source=accounts.sqlite;";
            Connection = new SQLiteConnection(connectionString);
            Connection.Open();
        }

        public void CloseChannelDB()
        {
            if (_channelDB != null)
            {
                _channelDB.Close();
                _channelDB.Dispose();
                _channelDB = null;
            }
        }

        public void Dispose()
        {
            CloseChannelDB();

            Connection.Close();
            Connection.Dispose();
        }

    }
}
