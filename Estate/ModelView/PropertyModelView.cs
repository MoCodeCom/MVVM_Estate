using Estate.Model.Data;
using Estate.Model.Interface;
using Estate.ModelView.Classes;
using Estate.ModelView.Interface;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Estate.View.Pages.Classes;
using System.IO;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Estate.View.UserControls;

namespace Estate.ModelView
{
    public class PropertyModelView<T> : IModelView<PropertyData>
    {
        public PropertyData propertyData;
        public AddressData propertyrAddressData;

        GetIdByName getIdByName = new GetIdByName();
        private string connStr = new ConnectionStr().conStr;

        //**************************************************************************//
        public PropertyModelView() 
        {
            
        }

        public async void DeleteAll()
        {
            await Task.Run(() =>
            {
                string commandStringAddress = "DELETE FROM PrpertyAddressTable";
                string commandStringLandlord = "DELETE FROM PropertyTable";

                try
                {

                    //step --1
                    SQLiteConnection conn = new SQLiteConnection(connStr);
                    SQLiteDataAdapter adAddress = new SQLiteDataAdapter(commandStringAddress, conn);
                    SQLiteDataAdapter adLandlord = new SQLiteDataAdapter(commandStringLandlord, conn);
                    conn.Open();
                    //step --2
                    adAddress.DeleteCommand = new SQLiteCommand(commandStringAddress, conn);
                    adLandlord.DeleteCommand = new SQLiteCommand(commandStringLandlord, conn);
                    //step --3
                    adAddress.DeleteCommand.ExecuteNonQuery();
                    adLandlord.DeleteCommand.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

        }

        public void DeleteById(int id)
        {
            string commandStringAddress = "DELETE FROM PropertyAddressTable WHERE property_id = " + id + ";";
            string commandStringLandlord = "DELETE FROM PropertyTable WHERE id = " + id + ";";
            //string commandString = "DELETE FROM AddressTable, LandlordTable WHERE "
            try
            {
                //step --1
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter adAddress = new SQLiteDataAdapter(commandStringAddress, conn);
                SQLiteDataAdapter adLandlord = new SQLiteDataAdapter(commandStringLandlord, conn);
                conn.Open();
                //step --2
                adAddress.DeleteCommand = new SQLiteCommand(commandStringAddress, conn);
                adLandlord.DeleteCommand = new SQLiteCommand(commandStringLandlord, conn);
                //step --3
                adAddress.DeleteCommand.ExecuteNonQuery();
                adLandlord.DeleteCommand.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<PropertyData> GetAll()
        {
            if (connStr == null) MessageBox.Show("There is no connection string.");
            List<PropertyData> li = new List<PropertyData>();


            string commandStr = "SELECT * FROM PropertyTable INNER JOIN PropertyAddressTable ON PropertyTable.id = PropertyAddressTable.property_id;";

            SQLiteConnection conn = new SQLiteConnection(connStr);
            SQLiteDataAdapter da = new SQLiteDataAdapter(commandStr, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int r = 0; r < dt.Rows.Count; r++)
            {

                li.Add(new PropertyData()
                {
                    Id = Convert.ToInt32(dt.Rows[r][0]),
                    OwnerName = dt.Rows[r][1].ToString(),
                    Bitmapimage_1 = ImageToBitmapcs.GetBitmapByImage(ImageProcess.ByteArrayToImage((System.Byte[])dt.Rows[r][3])),
                    Bitmapimage_2 = ImageToBitmapcs.GetBitmapByImage(ImageProcess.ByteArrayToImage((System.Byte[])dt.Rows[r][4])),
                    Bitmapimage_3 = ImageToBitmapcs.GetBitmapByImage(ImageProcess.ByteArrayToImage((System.Byte[])dt.Rows[r][5])),
                    Bitmapimage_4 = ImageToBitmapcs.GetBitmapByImage(ImageProcess.ByteArrayToImage((System.Byte[])dt.Rows[r][6])),
                    Image_1 = (System.Byte[])dt.Rows[r][3],
                    Image_2 = (System.Byte[])dt.Rows[r][4],
                    Image_3 = (System.Byte[])dt.Rows[r][5],
                    Image_4 = (System.Byte[])dt.Rows[r][6],

                    Phone = dt.Rows[r][7].ToString(),

                    Address = new AddressData()
                    {
                        LineOne = dt.Rows[r][10].ToString(),
                        LineTwo = dt.Rows[r][11].ToString(),
                        PostCode = dt.Rows[r][12].ToString(),
                        City = dt.Rows[r][13].ToString(),
                        Country = dt.Rows[r][14].ToString()
                    },
                });
            }
            
            
            return li;

        }
        public PropertyData GetById(int data)
        {
            PropertyData lld = new PropertyData();

            string CommandString = "SELECT * FROM PropertyTable WHERE id = " + data + "";
            try
            {
                SQLiteConnection con = new SQLiteConnection(connStr);
                SQLiteDataAdapter Landlordad = new SQLiteDataAdapter(CommandString, con);
                DataTable dt = new DataTable();
                Landlordad.Fill(dt);
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    lld = new PropertyData()
                    {
                        OwnerName = dt.Rows[r][1].ToString(),
                        Image_1 = (System.Byte[])dt.Rows[r][3],
                        Image_2 = (System.Byte[])dt.Rows[r][4],
                        Image_3 = (System.Byte[])dt.Rows[r][5],
                        Image_4 = (System.Byte[])dt.Rows[r][6],
                        Phone = dt.Rows[r][7].ToString(),
                    };
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return lld;
        }

        public void UpdateById(PropertyData item)
        {

            //pass property id by item when it's selected
            int propertyId = item.Id;

            string CommandStr = "UPDATE PropertyTable SET ownerName=@n, phone=@p, image_1=@i1, image_2=@i2, image_3=@i3,image_4=@i4 WHERE id=" + propertyId + ";";
            string CommandStringAddress = "UPDATE PropertyAddressTable SET lineOne='" + item.Address.LineOne + "', lineTwo='" + item.Address.LineTwo + "'" +
                ", postcode='" + item.Address.PostCode + "', country='" + item.Address.Country + "',city='" + item.Address.City + "'" +
                "WHERE property_id=" + propertyId + "; ";


            try
            {
                //Step -- 1
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter adAddress = new SQLiteDataAdapter(CommandStringAddress, conn);
                SQLiteDataAdapter daPorperty = new SQLiteDataAdapter(CommandStr, conn);

                conn.Open();
                daPorperty.UpdateCommand = new SQLiteCommand(CommandStr, conn);
                //************************************************************************************//

                SQLiteParameter piName = new SQLiteParameter("@n", DbType.String);
                SQLiteParameter piPhone = new SQLiteParameter("@p", DbType.String);
                SQLiteParameter pi1 = new SQLiteParameter("@i1", DbType.Binary);
                SQLiteParameter pi2 = new SQLiteParameter("@i2", DbType.Binary);
                SQLiteParameter pi3 = new SQLiteParameter("@i3", DbType.Binary);
                SQLiteParameter pi4 = new SQLiteParameter("@i4", DbType.Binary);

                piName.Value = item.OwnerName;
                piPhone.Value = item.Phone;
                pi1.Value = item.Image_1;
                pi2.Value = item.Image_2;
                pi3.Value = item.Image_3;
                pi4.Value = item.Image_4;

                daPorperty.UpdateCommand.Parameters.Add(piName);
                daPorperty.UpdateCommand.Parameters.Add(piPhone);
                daPorperty.UpdateCommand.Parameters.Add(pi1);
                daPorperty.UpdateCommand.Parameters.Add(pi2);
                daPorperty.UpdateCommand.Parameters.Add(pi3);
                daPorperty.UpdateCommand.Parameters.Add(pi4);


                //Step -- 2
                adAddress.UpdateCommand = new SQLiteCommand(CommandStringAddress, conn);
                //Step -- 3
                adAddress.UpdateCommand.ExecuteNonQuery();
                daPorperty.UpdateCommand.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void Add(PropertyData item)
        {
            string conStr = connStr;
            //Adding landlord data
            try
            {
                int id = GetLandlordIdByFullName.OwnerId("LandlordTable",item.OwnerName);
                string commandStr =
                    "INSERT INTO PropertyTable (ownerName, image_1,image_2, image_3, image_4,phone,owner_id) VALUES" +
                    "('" + item.OwnerName + "',@i1,@i2,@i3,@i4,'" + item.Phone + "','" + id + "');";
                
                SQLiteConnection con = new SQLiteConnection(conStr);
                SQLiteDataAdapter daPorperty = new SQLiteDataAdapter(commandStr, con);
                

                con.Open();
                daPorperty.InsertCommand = new SQLiteCommand(commandStr, con);
                /*************************************************************/
                SQLiteParameter pi1 = new SQLiteParameter("@i1",DbType.Binary);
                SQLiteParameter pi2 = new SQLiteParameter("@i2", DbType.Binary);
                SQLiteParameter pi3 = new SQLiteParameter("@i3", DbType.Binary);
                SQLiteParameter pi4 = new SQLiteParameter("@i4", DbType.Binary);

                pi1.Value = item.Image_1;
                pi2.Value = item.Image_2;
                pi3.Value = item.Image_3;
                pi4.Value = item.Image_4;

                daPorperty.InsertCommand.Parameters.Add(pi1);
                daPorperty.InsertCommand.Parameters.Add(pi2);
                daPorperty.InsertCommand.Parameters.Add(pi3);
                daPorperty.InsertCommand.Parameters.Add(pi4);

                /*************************************************************/

                daPorperty.InsertCommand.ExecuteNonQuery();
                con.Close();
                /************************************************/


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            //Adding Address data
            try
            {

                SQLiteConnection con = new SQLiteConnection(conStr);



                //Get last id count in database by checkphone class.
                int lastIdCount = Convert.ToInt32(getIdByName.GetId(item.OwnerName, "propertyTable"));

                string commandStrAddress = "INSERT INTO PropertyAddressTable (lineOne, lineTwo, postcode, city, country, property_id)" +
                    "VALUES ('" + item.Address.LineOne + "','" + item.Address.LineTwo + "','" + item.Address.PostCode + "','" + item.Address.City + "','" + item.Address.Country + "'," + lastIdCount + ");";

                SQLiteDataAdapter daAddress = new SQLiteDataAdapter(commandStrAddress, con);
                con.Open();
                daAddress.InsertCommand = new SQLiteCommand(commandStrAddress, con);
                daAddress.InsertCommand.ExecuteNonQuery();
                con.Close();
                /*************************************************/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        public int GetId(PropertyData propertyDataId)
        {
            int id = 0;

            string commandid =
                "SELECT id FROM PropertyTable WHERE ownerName='" + propertyDataId.OwnerName +
                "' AND postcode='" + propertyDataId.Address.PostCode + "' ;";
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
        public AddressData GetAddress(PropertyData ppd)
        {
            AddressData addressdata = new AddressData();

            int property_ID = Convert.ToInt32(GetId(ppd));
            string commStr = "SELECT * FROM PropertyAddressTable WHERE property_id= " + property_ID + "";

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
        public int GetIdByPostcode(string postcode)
        {
            int id = 0;

            string commandid =
                "SELECT property_id FROM PropertyAddressTable WHERE postcode='" + postcode +"' ;";
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
            MessageBox.Show(id.ToString());
            return id;
        }

    }

}
