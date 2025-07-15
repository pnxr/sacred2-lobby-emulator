using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System;

namespace S2Lobby
{
    public class Channels
    {
        private Program _program;

        private string GetConnectionString()
        {
            return "Server=" + Config.Get("database/mysql/ip") + ";" +
                   "Port=" + Config.Get("database/mysql/port") + ";" +
                   "Database=" + Config.Get("database/mysql/name") + ";" +
                   "User ID=" + Config.Get("database/mysql/user") + ";" +
                   "Password=" + Config.Get("database/mysql/pass") + ";" +
                   "Pooling=true";
        }

        public void Init(Program program)
        {
            _program = program;
            string connectionString = GetConnectionString();

            try
            {
                using (MySqlConnection mysql = new MySqlConnection(connectionString))
                {
                    mysql.Open();

                    using (MySqlTransaction transaction = mysql.BeginTransaction())
                    {
                        StringBuilder cmd = new StringBuilder();
                        cmd.AppendLine("CREATE TABLE IF NOT EXISTS channels (");
                        cmd.AppendLine("    channel_id          INTEGER PRIMARY KEY AUTO_INCREMENT");
                        cmd.AppendLine(",   channel_name        VARCHAR(127) NOT NULL");
                        cmd.AppendLine(",   channel_subject     VARCHAR(255)");
                        cmd.AppendLine(",   channel_creator     VARCHAR(127) NOT NULL");
                        cmd.AppendLine(",   creator_id          INTEGER NOT NULL");
                        cmd.AppendLine(",   channel_protected   INTEGER NOT NULL DEFAULT 0");
                        cmd.AppendLine(",   channel_password    VARCHAR(127)");
                        cmd.AppendLine(",   channel_hidden      INTEGER NOT NULL DEFAULT 0");
                        cmd.AppendLine(");");

                        using (MySqlCommand command = new MySqlCommand(cmd.ToString(), mysql, transaction))
                        {
                            if (command.ExecuteNonQuery() > 0)
                            {
                                string cmd1 = "INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected) VALUES ('System', 'System Channel', 'Admin', 0, 1);";
                                using (MySqlCommand command1 = new MySqlCommand(cmd1, mysql, transaction))
                                {
                                    command1.ExecuteNonQuery();
                                }

                                string cmd2 = "INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected) VALUES ('Lobby', 'Lobby Channel', 'Admin', 0, 1);";
                                using (MySqlCommand command2 = new MySqlCommand(cmd2, mysql, transaction))
                                {
                                    command2.ExecuteNonQuery();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }

                Logger.Log($"[Channel database ready]");
            }
            catch (Exception ex)
            {
                Logger.Log($"[Failed to access channel database] Exception: {ex.Message}");
                System.Environment.Exit(1);
            }
        }

        public uint Create(Channel channel)
        {
            if (Get(channel.Id) != null)
            {
                return 0;
            }

            uint lastId = 0;

            using (var mysql = new MySqlConnection(GetConnectionString()))
            {
                mysql.Open();

                StringBuilder cmd = new StringBuilder();
                cmd.AppendLine("INSERT INTO channels (channel_name, channel_subject, channel_creator, creator_id, channel_protected, channel_password, channel_hidden)" +
                               "VALUES (?channelName, ?channelSubject, ?channelCreator, ?channelCreatorId, ?channelProtected, ?channelPassword, ?channelHidden);");

                using (var transaction = mysql.BeginTransaction())
                {
                    using (var command = new MySqlCommand(cmd.ToString(), mysql, transaction))
                    {
                        command.Parameters.AddWithValue("channelName", channel.Name);
                        command.Parameters.AddWithValue("channelSubject", channel.Subject);
                        command.Parameters.AddWithValue("channelCreator", channel.Creator);
                        command.Parameters.AddWithValue("channelCreatorId", channel.CreatorId);
                        command.Parameters.AddWithValue("channelProtected", channel.Protected ? 1 : 0);
                        command.Parameters.AddWithValue("channelPassword", channel.Password);
                        command.Parameters.AddWithValue("channelHidden", channel.Hidden ? 1 : 0);

                        command.ExecuteNonQuery();
                        lastId = (uint)command.LastInsertedId;
                    }
                    transaction.Commit();
                }
            }

            return lastId;
        }

        public Channel Get(uint id)
        {
            return GetInternal("channel_id", new MySqlParameter("searchCondition", id));
        }

        private Channel GetInternal(string searchKey, MySqlParameter searchCondition)
        {
            using (var mysql = new MySqlConnection(GetConnectionString()))
            {
                mysql.Open();

                StringBuilder cmd = new StringBuilder();
                cmd.AppendLine("SELECT * FROM channels");
                cmd.AppendLine($"WHERE {searchKey} = ?searchCondition;");

                using (var command = new MySqlCommand(cmd.ToString(), mysql))
                {
                    command.Parameters.Add(searchCondition);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Channel()
                            {
                                Id = Convert.ToUInt32(reader["channel_id"]),
                                Name = reader["channel_name"].ToString(),
                                Subject = reader["channel_subject"].ToString(),
                                Creator = reader["channel_creator"].ToString(),
                                CreatorId = Convert.ToUInt32(reader["creator_id"]),
                                Protected = Convert.ToInt32(reader["channel_protected"]) != 0,
                                Password = reader["channel_password"].ToString(),
                                Hidden = Convert.ToInt32(reader["channel_hidden"]) != 0,
                                Persistent = true,
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Channel> GetAll()
        {
            var result = new List<Channel>();

            using (var mysql = new MySqlConnection(GetConnectionString()))
            {
                mysql.Open();

                string cmd = "SELECT * FROM channels ORDER BY channel_id;";
                using (var command = new MySqlCommand(cmd, mysql))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Channel()
                            {
                                Id = Convert.ToUInt32(reader["channel_id"]),
                                Name = reader["channel_name"].ToString(),
                                Subject = reader["channel_subject"].ToString(),
                                Creator = reader["channel_creator"].ToString(),
                                CreatorId = Convert.ToUInt32(reader["creator_id"]),
                                Protected = Convert.ToInt32(reader["channel_protected"]) != 0,
                                Password = reader["channel_password"].ToString(),
                                Hidden = Convert.ToInt32(reader["channel_hidden"]) != 0,
                                Persistent = true,
                            });
                        }
                    }
                }
            }
            return result;
        }

        public void Delete(uint id)
        {
            using (var mysql = new MySqlConnection(GetConnectionString()))
            {
                mysql.Open();
                string cmd = "DELETE FROM channels WHERE channel_protected = 0 AND channel_id = ?channelId;";
                using (var transaction = mysql.BeginTransaction())
                {
                    using (var command = new MySqlCommand(cmd, mysql, transaction))
                    {
                        command.Parameters.AddWithValue("channelId", id);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
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