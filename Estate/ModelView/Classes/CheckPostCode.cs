using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estate.ModelView.Classes
{
    public static class CheckPostCode<T>
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public static bool checkPostcodeExists(string postcodeStr, string tableName)
        {
            
            bool result = false;
            //string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string CommandString = "SELECT * FROM " + tableName + " WHERE postcode = '"+ postcodeStr +"';";
            try
            {

                SQLiteConnection con = new SQLiteConnection(ConnString);
                SQLiteDataAdapter adlandlord = new SQLiteDataAdapter(CommandString, con);
                DataTable dt = new DataTable();
                adlandlord.Fill(dt);
                result = dt.Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(result.ToString());
            return result;
        }
        public static int GetIdByPostcode(string postcodeStr, string tableNameStr )
        {
            int id = 0;

            //string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string commandid =
                "SELECT id FROM " + tableNameStr + " WHERE postcode= '" + postcodeStr + "';";
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
