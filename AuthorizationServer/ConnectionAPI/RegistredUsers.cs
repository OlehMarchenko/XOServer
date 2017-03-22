using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AuthorizationServer
{
    public class RegistredUsers
    {
        string databaseName;
        SQLiteConnection connection;

        public RegistredUsers()
        {
            databaseName = @"Users.db";
            connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
        }

        public bool Create(string name, string login, string password)
        {
            if (FindUser(login) == false)
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO 'RegistredUsers' ('name','login','password' ) VALUES ('" + name + "','" + login + "','" + password + "');", connection);
                command.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public string Read(string login, string password)
        {
            string loginUser = "";
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'RegistredUsers' WHERE login = '"+login+"' AND "+"password = '"+password+"';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                loginUser = record["login"].ToString();
            }
            if (loginUser != "" && loginUser != null)
                return loginUser;
            else
                return "Not registred";
        }

        public bool Update(string login, string newPass)
        {
            SQLiteCommand command = new SQLiteCommand("UPDATE 'RegistredUsers' SET password='" + newPass + "' WHERE login='" + login + "';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return true;
        }

        public string GetData(string login)
        {
            string pass = "";
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'RegistredUsers' WHERE login = '" + login+"';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                pass = record["password"].ToString();
            }
            return pass;
        }

        private bool FindUser(string login)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'RegistredUsers';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                if (login == record["login"].ToString())
                    return true;
            }

            return false;
        }
    }
}
