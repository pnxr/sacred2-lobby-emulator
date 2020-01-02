using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace S2Lobby
{
    public class Channels
    {
        private Program _program;

        public void Init(Program program)
        {
            _program = program;

            SQLiteConnection sql = new SQLiteConnection("Data Source=channels.sqlite;");
            sql.Open();

            SQLiteTransaction transaction = sql.BeginTransaction();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("CREATE TABLE IF NOT EXISTS channels (");
            cmd.AppendLine("    channel_id          INTEGER PRIMARY KEY AUTOINCREMENT");
            cmd.AppendLine(",   channel_name        VARCHAR(127) NOT NULL");
            cmd.AppendLine(",   channel_subject     VARCHAR(255)");
            cmd.AppendLine(",   channel_creator     VARCHAR(127) NOT NULL");
            cmd.AppendLine(",   creator_id          INTEGER NOT NULL");
            cmd.AppendLine(",   channel_protected   INTEGER NOT NULL DEFAULT(0)");
            cmd.AppendLine(",   channel_password    VARCHAR(127)");
            cmd.AppendLine(",   channel_hidden      INTEGER NOT NULL DEFAULT(0)");
            cmd.AppendLine(");");

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            if (command.ExecuteNonQuery() >= 0)
            {
                string cmd1 = "INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected) VALUES ('System', 'System Channel', 'Admin', 0, 1);";
                SQLiteCommand command1 = new SQLiteCommand(cmd1, sql, transaction);
                command1.ExecuteNonQuery();

                string cmd2 = "INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected) VALUES ('Lobby', 'Lobby Channel', 'Admin', 0, 1);";
                SQLiteCommand command2 = new SQLiteCommand(cmd2, sql, transaction);
                command2.ExecuteNonQuery();
            }

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();

            sql.Close();
            sql.Dispose();

            _program.Log($"[Channel database ready]");
        }

        public uint Create(SQLiteConnection sql, Channel channel)
        {
            Channel existing = Get(sql, channel.Id);
            if (existing != null)
            {
                return 0;
            }

            SQLiteParameter para1 = new SQLiteParameter();
            SQLiteParameter para2 = new SQLiteParameter();
            SQLiteParameter para3 = new SQLiteParameter();
            SQLiteParameter para4 = new SQLiteParameter();
            SQLiteParameter para5 = new SQLiteParameter();
            SQLiteParameter para6 = new SQLiteParameter();
            SQLiteParameter para7 = new SQLiteParameter();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected, channel_password, channel_hidden) VALUES (?, ?, ?, ?, ?, ?, ?);");

            para1.Value = channel.Name;
            para2.Value = channel.Subject;
            para3.Value = channel.Creator;
            para4.Value = channel.CreatorId;
            para5.Value = channel.Protected ? 1 : 0;
            para6.Value = channel.Password;
            para7.Value = channel.Hidden ? 1 : 0;

            SQLiteTransaction transaction = sql.BeginTransaction();

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);
            command.Parameters.Add(para3);
            command.Parameters.Add(para4);
            command.Parameters.Add(para5);
            command.Parameters.Add(para6);
            command.Parameters.Add(para7);

            command.ExecuteNonQuery();

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();

            return (uint)GetLastAutoIncrement(sql);
        }

        public Channel Get(SQLiteConnection sql, uint id)
        {
            SQLiteParameter para1 = new SQLiteParameter();
            para1.Value = id;

            return GetInternal(sql, "channel_id", para1);
        }

        private Channel GetInternal(SQLiteConnection sql, string field, SQLiteParameter para1)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("SELECT ");
            cmd.AppendLine("    channel_id");
            cmd.AppendLine(",   channel_name");
            cmd.AppendLine(",   channel_subject");
            cmd.AppendLine(",   channel_creator");
            cmd.AppendLine(",   creator_id");
            cmd.AppendLine(",   channel_protected");
            cmd.AppendLine(",   channel_password");
            cmd.AppendLine(",   channel_hidden");
            cmd.AppendLine("FROM channels");
            cmd.AppendLine($"WHERE {field} = ?;");

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql);
            command.Parameters.Add(para1);

            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            Channel channel = new Channel()
            {
                Id = (uint)(long)reader["channel_id"],
                Name = reader["channel_name"] as string,
                Subject = reader["channel_subject"] as string,
                Creator = reader["channel_creator"] as string,
                CreatorId = (uint)(long)reader["creator_id"],
                Protected = (long)reader["channel_protected"] != 0,
                Password = reader["channel_password"] as string,
                Hidden = (long)reader["channel_hidden"] != 0,
                Persistent = true,
            };

            reader.Close();
            command.Dispose();

            return channel;
        }

        public List<Channel> GetAll(SQLiteConnection sql)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("SELECT ");
            cmd.AppendLine("    channel_id");
            cmd.AppendLine(",   channel_name");
            cmd.AppendLine(",   channel_subject");
            cmd.AppendLine(",   channel_creator");
            cmd.AppendLine(",   creator_id");
            cmd.AppendLine(",   channel_protected");
            cmd.AppendLine(",   channel_password");
            cmd.AppendLine(",   channel_hidden");
            cmd.AppendLine("FROM channels");
            cmd.AppendLine("ORDER BY channel_id;");

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql);

            List<Channel> result = new List<Channel>();

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Channel channel = new Channel()
                {
                    Id = (uint)(long)reader["channel_id"],
                    Name = reader["channel_name"] as string,
                    Subject = reader["channel_subject"] as string,
                    Creator = reader["channel_creator"] as string,
                    CreatorId = (uint)(long)reader["creator_id"],
                    Protected = (long)reader["channel_protected"] != 0,
                    Password = reader["channel_password"] as string,
                    Hidden = (long)reader["channel_hidden"] != 0,
                    Persistent = true,
                };

                result.Add(channel);
            }

            reader.Close();
            command.Dispose();

            return result;
        }

        public void Delete(SQLiteConnection sql, uint id)
        {
            SQLiteParameter para1 = new SQLiteParameter();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("DELETE FROM channels WHERE channel_protected = 0 AND channel_id = ?;");

            para1.Value = id;

            SQLiteTransaction transaction = sql.BeginTransaction();

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            command.Parameters.Add(para1);

            command.ExecuteNonQuery();

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();
        }

        private static long GetLastAutoIncrement(SQLiteConnection sql)
        {
            string cmd= "SELECT last_insert_rowid();";
            SQLiteCommand command2 = new SQLiteCommand(cmd, sql);
            long scalar = (long) command2.ExecuteScalar();
            command2.Dispose();
            return scalar;
        }
    }

    public class Channel
    {
        public uint Id;
        public string Name;
        public string Subject;
        public string Creator;
        public uint CreatorId;
        public bool Protected;
        public string Password;
        public bool Hidden;
        public bool Persistent;
        public bool AutoDelete;
    }
}
