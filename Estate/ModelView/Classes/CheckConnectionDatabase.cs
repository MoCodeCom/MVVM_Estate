using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace Estate.ModelView.Classes
{
    public class CheckConnectionDatabase
    {
        ConnectionStr connStr = new ConnectionStr();
        SQLiteConnection conn;

        public bool checkConnection()
        {
            bool result = false;
            string connectionString = connStr.conStr;
            conn = new SQLiteConnection(connectionString);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                result = true;
            }
            else { result = false; }
            return result;
        }
    }
}
