using Estate.Model.Data;
using Estate.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Estate.ModelView.Classes
{
    public class GetAddressByData<T>
    {
        /*
        private static T _data;
        private string connStr = new ConnectionStr().conStr;
        //private GetIdByData<T> Getid = new GetIdByData<T>();
        //GetIdByData Getid = new GetIdByData();
        */
        //*************************************************************************************//
        /*
        public AddressData GetAddress(T lld)
        {
            AddressData addressdata = new AddressData();

            int landlord_ID = Convert.ToInt32(Getid);
            string commStr = "SELECT * FROM AddressTable WHERE landlord_id= " + landlord_ID + "";

            try
            {
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter ad = new SQLiteDataAdapter(commStr, conn);
                DataTable dt = new DataTable();

                ad.Fill(dt);

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    addressdata = new AddressData()
                    {
                        LineOne = dt.Rows[r][1].ToString(),
                        LineTwo = dt.Rows[r][2].ToString(),
                        PostCode = dt.Rows[r][3].ToString(),
                        City = dt.Rows[r][4].ToString(),
                        Country = dt.Rows[r][5].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return addressdata;
        }
        */

    }
}
