using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace S2Lobby
{
    public class Channels
    {
        private Program _program;

        public void Init(Program program)
        {
            _program = program;

            string connectionString =
           "Server=" + program.DbIp + ";" +
           "Port=" + program.DbPort + ";" +
           "Database=" + program.DbName + ";" +
           "User ID=" + program.DbUser + ";" +
           "Password=" + program.DbPass + ";" +
           "Pooling=false;";
            try
            {
                MySqlConnection mysql = new MySqlConnection(connectionString);
                mysql.Open();

                MySqlTransaction transaction = mysql.BeginTransaction();

                StringBuilder cmd = new StringBuilder();
                cmd.AppendLine("CREATE TABLE IF NOT EXISTS channels (");
                cmd.AppendLine("    channel_id          INTEGER PRIMARY KEY AUTO_INCREMENT");
                cmd.AppendLine(",   channel_name        VARCHAR(127) NOT NULL");
                cmd.AppendLine(",   channel_subject     VARCHAR(255)");
                cmd.AppendLine(",   channel_creator     VARCHAR(127) NOT NULL");
                cmd.AppendLine(",   creator_id          INTEGER NOT NULL");
                cmd.AppendLine(",   channel_protected   INTEGER NOT NULL DEFAULT(0)");
                cmd.AppendLine(",   channel_password    VARCHAR(127)");
                cmd.AppendLine(",   channel_hidden      INTEGER NOT NULL DEFAULT(0)");
                cmd.AppendLine(");");

                MySqlCommand command = mysql.CreateCommand();
                command.CommandText = cmd.ToString();
                command.Transaction = transaction;

                if (command.ExecuteNonQuery() > 0)
                {
                    string cmd1 = "INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected) VALUES ('System', 'System Channel', 'Admin', 0, 1);";
                    MySqlCommand command1 = new MySqlCommand(cmd1, mysql, transaction);
                    command1.ExecuteNonQuery();

                    string cmd2 = "INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected) VALUES ('Lobby', 'Lobby Channel', 'Admin', 0, 1);";
                    MySqlCommand command2 = new MySqlCommand(cmd2, mysql, transaction);
                    command2.ExecuteNonQuery();
                }
                transaction.Commit();

                command.Dispose();
                transaction.Dispose();

                mysql.Close();
                mysql.Dispose();

            _program.Log($"[Channel database ready]");
            }
            catch
            {
                _program.Log($"[Failed to access channel database]");
                System.Environment.Exit(1);
            }
        }

        public uint Create(MySqlConnection mysql, Channel channel)
        {
            Channel existing = Get(mysql, channel.Id);
            if (existing != null)
            {
                return 0;
            }

            MySqlParameter channelName = new MySqlParameter("channelName", channel.Name);
            MySqlParameter channelSubject = new MySqlParameter("channelSubject", channel.Subject);
            MySqlParameter channelCreator = new MySqlParameter("channelCreator", channel.Creator);
            MySqlParameter channelCreatorId = new MySqlParameter("channelCreatorId", channel.CreatorId);
            MySqlParameter channelProtected = new MySqlParameter("channelProtected", channel.Protected ? 1 : 0);
            MySqlParameter channelPassword = new MySqlParameter("channelPassword", channel.Password);
            MySqlParameter channelHidden = new MySqlParameter("channelHidden", channel.Hidden ? 1 : 0);

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected, channel_password, channel_hidden)" +
                           "VALUES (?channelName, ?channelSubject, ?channelCreator, ?channelCreatorId, ?channelProtected, ?channelPassword, ?channelHidden);");

            MySqlTransaction transaction = mysql.BeginTransaction();

            MySqlCommand command = new MySqlCommand(cmd.ToString(), mysql, transaction);
            command.Parameters.Add(channelName);
            command.Parameters.Add(channelSubject);
            command.Parameters.Add(channelCreator);
            command.Parameters.Add(channelCreatorId);
            command.Parameters.Add(channelProtected);
            command.Parameters.Add(channelPassword);
            command.Parameters.Add(channelHidden);

            command.ExecuteNonQuery();

            transaction.Commit();
            uint lastId = (uint)command.LastInsertedId;
            command.Dispose();
            transaction.Dispose();

            return lastId;
        }

        public Channel Get(MySqlConnection mysql, uint id)
        {
            return GetInternal(mysql, "channel_id", new MySqlParameter("searchCondition", id));
        }

        private Channel GetInternal(MySqlConnection mysql, string searchKey, MySqlParameter searchCondition)
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
            cmd.AppendLine($"WHERE {searchKey} = ?searchCondition;");

            MySqlCommand command = new MySqlCommand(cmd.ToString(), mysql);
            command.Parameters.Add(searchCondition);

            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            Channel channel = new Channel()
            {
                Id = uint.Parse(reader["channel_id"].ToString()),
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

        public List<Channel> GetAll(MySqlConnection mysql)
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

            MySqlCommand command = new MySqlCommand(cmd.ToString(), mysql);

            List<Channel> result = new List<Channel>();

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Channel channel = new Channel()
                {
                    Id = uint.Parse(reader["channel_id"].ToString()),
                    Name = reader["channel_name"] as string,
                    Subject = reader["channel_subject"] as string,
                    Creator = reader["channel_creator"] as string,
                    CreatorId = uint.Parse(reader["creator_id"].ToString()),
                    Protected = uint.Parse(reader["channel_protected"].ToString()) != 0,
                    Password = reader["channel_password"] as string,
                    Hidden = uint.Parse(reader["channel_hidden"].ToString()) != 0,
                    Persistent = true,
                };

                result.Add(channel);
            }

            reader.Close();
            command.Dispose();

            return result;
        }

        public void Delete(MySqlConnection mysql, uint id)
        {
            MySqlParameter channelId = new MySqlParameter("channelId", id);

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("DELETE FROM channels WHERE channel_protected = 0 AND channel_id = ?channelId;");

            MySqlTransaction transaction = mysql.BeginTransaction();

            MySqlCommand command = new MySqlCommand(cmd.ToString(), mysql, transaction);
            command.Parameters.Add(channelId);

            command.ExecuteNonQuery();

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();
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
