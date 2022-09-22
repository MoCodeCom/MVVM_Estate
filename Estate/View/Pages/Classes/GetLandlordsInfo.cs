using Estate.Model.Data;
using Estate.ModelView.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Estate.View.Pages.Classes
{
    public class GetLandlordsInfo
    {

        private string connStr = new ConnectionStr().conStr;
        public List<string> GetLandlordsName()
        {
            if (connStr == null) MessageBox.Show("There is no connection string.");
            string commStr = "SELECT firstName, lastName FROM LandlordTable;";
            List<string> liNames = new List<string>();
            try
            {
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter ada = new SQLiteDataAdapter(commStr,conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    liNames.Add(dt.Rows[r][0].ToString()+" " + dt.Rows[r][1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return liNames;
        }

        
    }
}
