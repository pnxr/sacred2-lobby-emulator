using System.Text;
using MySql.Data.MySqlClient;

namespace S2Lobby
{
    public class Accounts
    {
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
            string connectionString = GetConnectionString();
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(connectionString))
                {
                    mysql.Open();

                    MySqlTransaction transaction = mysql.BeginTransaction();

                    StringBuilder cmd = new StringBuilder();
                    cmd.AppendLine("CREATE TABLE IF NOT EXISTS accounts (");
                    cmd.AppendLine("    account_id          INTEGER PRIMARY KEY AUTO_INCREMENT");
                    cmd.AppendLine(",   user_name           VARCHAR(127) NOT NULL");
                    cmd.AppendLine(",   user_name_upper     VARCHAR(127) NOT NULL");
                    cmd.AppendLine(",   user_password       BLOB NOT NULL");
                    cmd.AppendLine(",   user_cdkey          BLOB NOT NULL");
                    cmd.AppendLine(",   user_email          VARCHAR(255)");
                    cmd.AppendLine(",   user_data           BLOB");
                    cmd.AppendLine(",   player_nickname     VARCHAR(127)");
                    cmd.AppendLine(");");

                    MySqlCommand command = mysql.CreateCommand();
                    command.CommandText = cmd.ToString();
                    command.Transaction = transaction;

                    command.ExecuteNonQuery();

                    transaction.Commit();

                    command.Dispose();
                    transaction.Dispose();
                }

                Logger.Log($"[Account database ready]");
            }
            catch (MySqlException ex)
            {
                Logger.Log($"[Failed to access account database] {ex.Message}");
                Logger.Log(connectionString);
                System.Environment.Exit(1);
            }
        }

        public uint Create(string username, byte[] password, byte[] cdKey)
        {
            Account account = Get(username);
            if (account != null)
            {
                return 0;
            }

            long insertedId = -1;

            using (var mysql = new MySqlConnection(GetConnectionString()))
            {
                mysql.Open();

                StringBuilder cmd = new StringBuilder();
                cmd.AppendLine("INSERT INTO accounts (user_name, user_name_upper, user_password, user_cdkey) VALUES (?p1, ?p2, ?p3, ?p4);");

                MySqlTransaction transaction = mysql.BeginTransaction();
                MySqlCommand command = mysql.CreateCommand();

                command.CommandText = cmd.ToString();
                command.Transaction = transaction;

                command.Parameters.Add(new MySqlParameter("p1", username));
                command.Parameters.Add(new MySqlParameter("p2", username.ToUpperInvariant()));
                command.Parameters.Add(new MySqlParameter("p3", password));
                command.Parameters.Add(new MySqlParameter("p4", cdKey));

                command.ExecuteNonQuery();
                insertedId = command.LastInsertedId;

                transaction.Commit();

                command.Dispose();
                transaction.Dispose();
            }

            return (uint)insertedId;
        }

        public Account Get(string name)
        {
            return GetInternal("user_name_upper", new MySqlParameter("searchCondition", name.ToUpperInvariant()));
        }

        public Account Get(uint id)
        {
            return GetInternal("account_id", new MySqlParameter("searchCondition", id));
        }

        private Account GetInternal(string searchKey, MySqlParameter searchCondition)
        {
            using (var mysql = new MySqlConnection(GetConnectionString()))
            {
                mysql.Open();

                StringBuilder cmd = new StringBuilder();
                cmd.AppendLine("SELECT ");
                cmd.AppendLine("    account_id");
                cmd.AppendLine(",   user_name");
                cmd.AppendLine(",   user_password");
                cmd.AppendLine(",   user_cdkey");
                cmd.AppendLine(",   user_email");
                cmd.AppendLine(",   user_data");
                cmd.AppendLine(",   player_nickname");
                cmd.AppendLine("FROM accounts");
                cmd.AppendLine($"WHERE {searchKey} = ?searchCondition;");

                using (MySqlCommand command = new MySqlCommand(cmd.ToString(), mysql))
                {
                    command.Parameters.Add(searchCondition);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Account()
                            {
                                Id = uint.Parse(reader["account_id"].ToString()),
                                UserName = reader["user_name"] as string,
                                Password = reader["user_password"] as byte[],
                                CdKey = reader["user_cdkey"] as byte[],
                                Email = reader["user_email"] as string,
                                UserData = reader["user_data"] as byte[],
                                PlayerName = reader["player_nickname"] as string,
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void ExecuteUpdate(string query, params MySqlParameter[] parameters)
        {
            using (var mysql = new MySqlConnection(GetConnectionString()))
            {
                mysql.Open();
                using (var transaction = mysql.BeginTransaction())
                {
                    using (var command = mysql.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = query;
                        command.Parameters.AddRange(parameters);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public void SetNickname(uint id, string name)
        {
            string cmd = "UPDATE accounts SET player_nickname=?p1 WHERE account_id=?p2;";
            ExecuteUpdate(cmd,
                new MySqlParameter("p1", name),
                new MySqlParameter("p2", id)
            );
        }

        public void SetEmail(uint id, string email)
        {
            string cmd = "UPDATE accounts SET user_email=?p1 WHERE account_id=?p2;";
            ExecuteUpdate(cmd,
                new MySqlParameter("p1", email),
                new MySqlParameter("p2", id)
            );
        }

        public void SetUserData(uint id, byte[] data)
        {
            string cmd = "UPDATE accounts SET user_data=?p1 WHERE account_id=?p2;";
            ExecuteUpdate(cmd,
                new MySqlParameter("p1", data),
                new MySqlParameter("p2", id)
            );
        }
    }

    public class Account
    {
        public uint Id;
        public string UserName;
        public byte[] Password;
        public byte[] CdKey;
        public string Email;
        public byte[] UserData;
        public string PlayerName;
    }
}