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

namespace Estate.ModelView
{
    public class PropertyModelView<T> : IModelView<PropertyData>
    {


        public PropertyData propertyData;
        public LandlordData lld;
        public AddressData propertyrAddressData;
        //CheckPhone<PropertyData> checkPhone = new CheckPhone<PropertyData>();
        GetIdByName getIdByName = new GetIdByName();
        private string connStr = new ConnectionStr().conStr;
        //string conStrNormal = "Data Source = ./maindb.db";


        //**************************************************************************//
        public PropertyModelView() { }

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
                    OwnerName = dt.Rows[r][1].ToString(),
                    Image_1 = (System.Byte[])dt.Rows[r][3],
                    Image_2 = (System.Byte[])dt.Rows[r][4],
                    Image_3 = (System.Byte[])dt.Rows[r][5],
                    Image_4 = (System.Byte[])dt.Rows[r][6],
                    Phone = dt.Rows[r][7].ToString(),

                    Address = new AddressData()
                    {
                        LineOne = dt.Rows[r][8].ToString(),
                        LineTwo = dt.Rows[r][9].ToString(),
                        PostCode = dt.Rows[r][10].ToString(),
                        City = dt.Rows[r][11].ToString(),
                        Country = dt.Rows[r][12].ToString()
                    },
                }); ;
            }
            return li;

        }
        public PropertyData GetById(int id)
        {
            PropertyData lld = new PropertyData();

            string CommandString = "SELECT * FROM PropertyTable WHERE id = " + id + "";
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

            //pass landlord id by item when it's selected
            int propertyId = item.Id;

            string CommandStringLandlord = "UPDATE PropertyTable SET ownerName='" + item.OwnerName + "', phone='" + item.Phone + "'" +
                ", image_1='" + item.Image_1 + "', image_2='" + item.Image_2 + "', image_3='" + item.Image_3 + "'," +
                "image_4='" + item.Image_4 + "' WHERE id=" + propertyId + ";";

            string CommandStringAddress = "UPDATE PropertyAddressTable SET lineOne='" + item.Address.LineOne + "', lineTwo='" + item.Address.LineTwo + "'" +
                ", postcode='" + item.Address.PostCode + "', country='" + item.Address.Country + "',city='" + item.Address.City + "'" +
                "WHERE property_id=" + propertyId + "; ";


            try
            {
                //Step -- 1
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter adAddress = new SQLiteDataAdapter(CommandStringAddress, conn);
                SQLiteDataAdapter adLandlord = new SQLiteDataAdapter(CommandStringLandlord, conn);

                conn.Open();
                //Step -- 2
                adAddress.UpdateCommand = new SQLiteCommand(CommandStringAddress, conn);
                adLandlord.UpdateCommand = new SQLiteCommand(CommandStringLandlord, conn);

                //Step -- 3
                adAddress.UpdateCommand.ExecuteNonQuery();
                adLandlord.UpdateCommand.ExecuteNonQuery();
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

                string commandStrLandlord =
                    "INSERT INTO LandlordTable (ownerName, image_1,image_2, image_3, image_4,phone) VALUES" +
                    "('" + item.OwnerName + "','" + item.Image_1 + "','" + item.Image_2 + "','" + item.Image_3 + "','" + item.Image_4 + "','" + item.Phone + "');";

                SQLiteConnection con = new SQLiteConnection(conStr);
                SQLiteDataAdapter daLandlord = new SQLiteDataAdapter(commandStrLandlord, con);


                con.Open();
                daLandlord.InsertCommand = new SQLiteCommand(commandStrLandlord, con);
                daLandlord.InsertCommand.ExecuteNonQuery();
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

                string commandStrAddress = "INSERT INTO AddressTable (lineOne, lineTwo, postcode, city, contry, landlord_id)" +
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

        public string GetUniqOwnerName(LandlordData lld)
        {
            string selectStr = "";
        }



    }

}
