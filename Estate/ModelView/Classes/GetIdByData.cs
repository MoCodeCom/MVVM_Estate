using Estate.Model.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Estate.ModelView.Classes
{
    public class GetIdByData<T>
    {
        private string connStr = new ConnectionStr().conStr;
        //LandlordData d = new LandlordData();
        /*
        public int GetId(T data)
        {

            int id = 0;
            MessageBox.Show(data+".FirstName");
            string commandid =
                "SELECT id FROM LandlordTable WHERE firstName='" + data +".LastName" +
                "' AND lastName='" + data +".LastName" + "' AND phone='" + data +".Phone" + "';";
            
            try
            {
                SQLiteConnection conId = new SQLiteConnection(connStr);

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
        */

    }
}
