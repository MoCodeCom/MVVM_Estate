using Estate.View.Pages.Classes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Estate.ModelView.Classes
{
    public class DefaultImage
    {
        

        private string connStr = new ConnectionStr().conStr;
        
        public bool GetImageByName(string name)
        {
            string commStr = "SELECT * From AppDefaultImagesTable WHERE imageName ='"+name+"'; ";
            bool result = false;
            try
            {
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter ada = new SQLiteDataAdapter(commStr, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                for (int i=0;i<dt.Rows.Count;i++)
                {
                    if (dt.Rows[i][1].ToString() == name)
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        public byte[] GetDefaultImageBytes(string name) 
        {
            byte[] result = new byte[]{};
            string commStr = "SELECT * From AppDefaultImagesTable WHERE imageName ='"+name+"'; ";
            try
            {
                SQLiteConnection comm = new SQLiteConnection(connStr);
                SQLiteDataAdapter ada = new SQLiteDataAdapter(commStr, comm);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() == name)
                    {
                        result = (System.Byte[])dt.Rows[i][2];
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public void UpdateDefaltImage()
        {
            ///
            /////
            ///
        }

        public void AddDefaultImage(byte[] data)
        {
            
            try
            {
                string comm = "INSERT INTO AppDefaultImagesTable (imageName, image) VALUES(@name,@i);";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteCommand cmd = new SQLiteCommand(comm, conn);
                cmd.Parameters.Clear();

                cmd.Parameters.Add("name", System.Data.DbType.String);
                cmd.Parameters["name"].Value = "property_Default_Image";

                cmd.Parameters.Add("i", DbType.Binary);
                cmd.Parameters["i"].Value = data;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Adding is done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

    }
}
