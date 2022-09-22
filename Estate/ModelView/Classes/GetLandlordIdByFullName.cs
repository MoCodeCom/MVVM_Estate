using Estate.Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView.Classes
{

    public static class GetLandlordIdByFullName
    {
        private static string connStr = new ConnectionStr().conStr;
        public static int OwnerId(string tableName,string FullName)
        {
            int id = 0;
            var name = FullName.Split(' ');
            string fName = name[0];
            string lName = name[1];

            string comm = "SELECT id FROM '"+ tableName + "' WHERE firstName='" + fName + "' AND lastName='" + lName + "';";
            SQLiteConnection con = new SQLiteConnection(connStr);
            SQLiteDataAdapter ada = new SQLiteDataAdapter(comm, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            for (int i = 0; i < 1; i++)
            {
                id = Convert.ToInt32(dt.Rows[i][0]);
            }


            return id;
        }
    }

    //public static class GetPropertyIdByFullName
    //{
    //    private static string connStr = new ConnectionStr().conStr;
    //    public static int OwnerId(string tableName, string FullName)
    //    {
    //        int id = 0;

    //        string comm = "SELECT id FROM '" + tableName + "' WHERE ownerName='" + FullName + "';";
    //        SQLiteConnection con = new SQLiteConnection(connStr);
    //        SQLiteDataAdapter ada = new SQLiteDataAdapter(comm, con);
    //        DataTable dt = new DataTable();
    //        ada.Fill(dt);
    //        for (int i = 0; i < 1; i++)
    //        {
    //            id = Convert.ToInt32(dt.Rows[i][0]);
    //        }


    //        return id;
    //    }
    //}
}
