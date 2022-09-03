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
    public class TenantModelView<T> : IModelView<TenantData>
    {
        public TenantData tenantData;
        public AddressData addressData;
        CheckPhone<TenantData> checkPhone = new CheckPhone<TenantData>();
        private string connStr = new ConnectionStr().conStr;

        public TenantModelView()
        {

        }

        //*****************************************************************************************************//
        public async void DeleteAll()
        {
            await Task.Run(() =>
            {
                string commandStringAddress = "DELETE FROM TenantAddressTable";
                string commandStringTenant = "DELETE FROM TenantTable";

                try
                {

                    //step --1
                    SQLiteConnection conn = new SQLiteConnection(connStr);
                    SQLiteDataAdapter adAddress = new SQLiteDataAdapter(commandStringAddress, conn);
                    SQLiteDataAdapter adTenant = new SQLiteDataAdapter(commandStringTenant, conn);
                    conn.Open();
                    //step --2
                    adAddress.DeleteCommand = new SQLiteCommand(commandStringAddress, conn);
                    adTenant.DeleteCommand = new SQLiteCommand(commandStringTenant, conn);
                    //step --3
                    adAddress.DeleteCommand.ExecuteNonQuery();
                    adTenant.DeleteCommand.ExecuteNonQuery();
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
            string commandStringAddress = "DELETE FROM TenantAddressTable WHERE tenant_id = " + id + ";";
            string commandStringTenant = "DELETE FROM TenantTable WHERE id = " + id + ";";
           
            try
            {
                //step --1
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter adAddress = new SQLiteDataAdapter(commandStringAddress, conn);
                SQLiteDataAdapter adTenant = new SQLiteDataAdapter(commandStringTenant, conn);
                conn.Open();
                //step --2
                adAddress.DeleteCommand = new SQLiteCommand(commandStringAddress, conn);
                adTenant.DeleteCommand = new SQLiteCommand(commandStringTenant, conn);
                //step --3
                adAddress.DeleteCommand.ExecuteNonQuery();
                adTenant.DeleteCommand.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<TenantData> GetAll()
        {

            List<TenantData> li = new List<TenantData>();


            string commandStr = "SELECT * FROM TenantTable INNER JOIN TenantAddressTable ON TenantTable.id = TenantAddressTable.tenant_id;";

            SQLiteConnection conn = new SQLiteConnection(connStr);
            SQLiteDataAdapter da = new SQLiteDataAdapter(commandStr, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            for (int r = 0; r < dt.Rows.Count; r++)
            {
                li.Add(new TenantData()
                {
                    FirstName = dt.Rows[r][1].ToString(),
                    LastName = dt.Rows[r][2].ToString(),
                    Phone = dt.Rows[r][3].ToString(),
                    Email = dt.Rows[r][4].ToString(),

                    Address = new AddressData()
                    {
                        LineOne = dt.Rows[r][6].ToString(),
                        LineTwo = dt.Rows[r][7].ToString(),
                        PostCode = dt.Rows[r][8].ToString(),
                        City = dt.Rows[r][9].ToString(),
                        Country = dt.Rows[r][10].ToString()
                    },
                }); ;
            }
            return li;

        }
        public TenantData GetById(int id)
        {
            TenantData ttd = new TenantData();

            string CommandString = "SELECT * FROM TenantTable WHERE id = " + id + "";
            try
            {
                SQLiteConnection con = new SQLiteConnection(connStr);
                SQLiteDataAdapter adTenant = new SQLiteDataAdapter(CommandString, con);
                DataTable dt = new DataTable();
                adTenant.Fill(dt);
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    ttd = new TenantData()
                    {
                        FirstName = dt.Rows[r][1].ToString(),
                        LastName = dt.Rows[r][2].ToString(),
                        Phone = dt.Rows[r][3].ToString(),
                        Email = dt.Rows[r][4].ToString()
                    };
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ttd;
        }

        public void UpdateById(TenantData item)
        {

            //pass tenant id by item when it's selected
            int tenantId = item.Id;

            string CommandStringTenant = "UPDATE TenantTable SET FirstName='" + item.FirstName + "', LastName='" + item.LastName + "'" +
                ", email='" + item.Email + "', phone='" + item.Phone + "' WHERE id=" + tenantId + ";";

            string CommandStringAddress = "UPDATE TenantAddressTable SET lineOne='" + item.Address.LineOne + "', lineTwo='" + item.Address.LineTwo + "'" +
                ", postcode='" + item.Address.PostCode + "', contry='" + item.Address.Country + "',city='" + item.Address.City + "'" +
                "WHERE tenant_id=" + tenantId + "; ";


            try
            {
                //Step -- 1
                SQLiteConnection conn = new SQLiteConnection(connStr);
                SQLiteDataAdapter adAddress = new SQLiteDataAdapter(CommandStringAddress, conn);
                SQLiteDataAdapter adTenant = new SQLiteDataAdapter(CommandStringTenant, conn);

                conn.Open();
                //Step -- 2
                adAddress.UpdateCommand = new SQLiteCommand(CommandStringAddress, conn);
                adTenant.UpdateCommand = new SQLiteCommand(CommandStringTenant, conn);

                //Step -- 3
                adAddress.UpdateCommand.ExecuteNonQuery();
                adTenant.UpdateCommand.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void Add(TenantData item)
        {
            string conStr = connStr;
            //Adding tenant data
            try
            {

                string commandStrTenant =
                    "INSERT INTO TenantTable (firstName, lastName,phone,email) VALUES" +
                    "('" + item.FirstName + "','" + item.LastName + "','" + item.Phone + "','" + item.Email + "');";

                SQLiteConnection con = new SQLiteConnection(conStr);
                SQLiteDataAdapter daTenant = new SQLiteDataAdapter(commandStrTenant, con);


                con.Open();
                daTenant.InsertCommand = new SQLiteCommand(commandStrTenant, con);
                daTenant.InsertCommand.ExecuteNonQuery();
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
                int lastIdCount = Convert.ToInt32(checkPhone.GetIdByPhone(item.Phone, "TenantTable"));

                string commandStrAddress = "INSERT INTO TenantAddressTable (lineOne, lineTwo, postcode, city, contry, tenant_id)" +
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


        public int GetId(TenantData tenantDataId)
        {
            int id = 0;

            string commandid =
                "SELECT id FROM TenantTable WHERE firstName='" + tenantDataId.FirstName +
                "' AND lastName='" + tenantDataId.LastName + "' AND phone='" + tenantDataId.Phone + "';";
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
        public AddressData GetAddress(TenantData ttd)
        {
            AddressData addressdata = new AddressData();

            int tenant_ID = Convert.ToInt32(GetId(ttd));
            string commStr = "SELECT * FROM TenantAddressTable WHERE tenant_id= " + tenant_ID + "";

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


    }
}
