using System.Data.SQLite;
using System.Text;

namespace S2Lobby
{
    public class Accounts
    {
        private Program _program;

        public void Init(Program program)
        {
            _program = program;

            SQLiteConnection sql = new SQLiteConnection("Data Source=accounts.sqlite;");
            sql.Open();

            SQLiteTransaction transaction = sql.BeginTransaction();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("CREATE TABLE IF NOT EXISTS accounts (");
            cmd.AppendLine("    account_id          INTEGER PRIMARY KEY AUTOINCREMENT");
            cmd.AppendLine(",   user_name           VARCHAR(127) NOT NULL");
            cmd.AppendLine(",   user_name_upper     VARCHAR(127) NOT NULL");
            cmd.AppendLine(",   user_password       BLOB NOT NULL");
            cmd.AppendLine(",   user_cdkey          BLOB NOT NULL");
            cmd.AppendLine(",   user_email          VARCHAR(255)");
            cmd.AppendLine(",   user_data           BLOB");
            cmd.AppendLine(",   player_nickname     VARCHAR(127)");
            cmd.AppendLine(");");

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            command.ExecuteNonQuery();

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();

            sql.Close();
            sql.Dispose();

            _program.Log($"[Account database ready]");
        }

        public uint Create(SQLiteConnection sql, string username, byte[] password, byte[] cdKey)
        {
            Account account = Get(sql, username);
            if (account != null)
            {
                return 0;
            }

            SQLiteParameter para1 = new SQLiteParameter();
            SQLiteParameter para2 = new SQLiteParameter();
            SQLiteParameter para3 = new SQLiteParameter();
            SQLiteParameter para4 = new SQLiteParameter();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("INSERT INTO accounts (user_name, user_name_upper, user_password, user_cdkey) VALUES (?, ?, ?, ?);");

            para1.Value = username;
            para2.Value = username.ToUpperInvariant();
            para3.Value = password;
            para4.Value = cdKey;

            SQLiteTransaction transaction = sql.BeginTransaction();

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);
            command.Parameters.Add(para3);
            command.Parameters.Add(para4);

            command.ExecuteNonQuery();

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();

            return (uint)GetLastAutoIncrement(sql);
        }

        public Account Get(SQLiteConnection sql, string name)
        {
            SQLiteParameter para1 = new SQLiteParameter();
            para1.Value = name.ToUpperInvariant();

            return GetInternal(sql, "user_name_upper", para1);
        }

        public Account Get(SQLiteConnection sql, uint id)
        {
            SQLiteParameter para1 = new SQLiteParameter();
            para1.Value = id;

            return GetInternal(sql, "account_id", para1);
        }

        private Account GetInternal(SQLiteConnection sql, string field, SQLiteParameter para1)
        {
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
            cmd.AppendLine($"WHERE {field} = ?;");

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql);
            command.Parameters.Add(para1);

            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            Account account = new Account()
            {
                Id = (uint)(long)reader["account_id"],
                UserName = reader["user_name"] as string,
                Password = reader["user_password"] as byte[],
                CdKey = reader["user_cdkey"] as byte[],
                Email = reader["user_email"] as string,
                UserData = reader["user_data"] as byte[],
                PlayerName = reader["player_nickname"] as string,
            };

            reader.Close();
            command.Dispose();

            return account;
        }

        public void SetNickname(SQLiteConnection sql, uint id, string name)
        {
            SQLiteParameter para1 = new SQLiteParameter();
            SQLiteParameter para2 = new SQLiteParameter();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("UPDATE accounts SET player_nickname = ? WHERE account_id = ?;");

            para1.Value = name;
            para2.Value = id;

            SQLiteTransaction transaction = sql.BeginTransaction();

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);

            command.ExecuteNonQuery();

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();
        }

        public void SetEmail(SQLiteConnection sql, uint id, string email)
        {
            SQLiteParameter para1 = new SQLiteParameter();
            SQLiteParameter para2 = new SQLiteParameter();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("UPDATE accounts SET user_email = ? WHERE account_id = ?;");

            para1.Value = email;
            para2.Value = id;

            SQLiteTransaction transaction = sql.BeginTransaction();

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);

            command.ExecuteNonQuery();

            transaction.Commit();

            command.Dispose();
            transaction.Dispose();
        }

        public void SetUserData(SQLiteConnection sql, uint id, byte[] data)
        {
            SQLiteParameter para1 = new SQLiteParameter();
            SQLiteParameter para2 = new SQLiteParameter();

            StringBuilder cmd = new StringBuilder();
            cmd.AppendLine("UPDATE accounts SET user_data = ? WHERE account_id = ?;");

            para1.Value = data;
            para2.Value = id;

            SQLiteTransaction transaction = sql.BeginTransaction();

            SQLiteCommand command = new SQLiteCommand(cmd.ToString(), sql, transaction);
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);

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
