using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;

namespace Estate.ModelView.Classes
{
    public class GetIdByOwnerName
    {
        private string ConnString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public int GetIdByName(string nameStr, string tableName)
        {
            int id = 0;

            //string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string commandid =
                "SELECT id FROM " + tableName + " WHERE ownerName= '" + nameStr + "';";
            try
            {
                SQLiteConnection conId = new SQLiteConnection(ConnString);
                SQLiteDataAdapter ad = new SQLiteDataAdapter(commandid, conId);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id = Convert.ToInt32(dt.Rows[i][0]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }
    }
}
