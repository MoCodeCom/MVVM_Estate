﻿using Estate.Model.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace Estate.ModelView.Classes
{
    public class CheckPhone<T>
    {
        private string ConnString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public bool checkPhoneExists(T lld, string tableName)
        {
            bool result = false;
            //string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string CommandString = "SELECT * FROM "+tableName+" WHERE phone = '" + lld+".Phone" + "';";
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
            return result;
        }

        public int GetIdByPhone(string phoneStr, string tableName)
        {
            int id = 0;
            //string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string commandid =
                "SELECT id FROM "+tableName+" WHERE phone='" + phoneStr + "';";
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
        public static bool IsValidPhone(string phone)
        {
            Regex n = new Regex("^[0-9]{11}$");
            return n.IsMatch(phone);
        }
    }
}
