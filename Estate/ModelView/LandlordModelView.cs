using Estate.Model.Data;
using Estate.Model.Interface;
using Estate.ModelView.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;
using Estate.ModelView.CommandStrings;
using System.Windows;
using Estate.View.Pages.SubPages.Landlord;
using Estate.ModelView.Classes;

namespace Estate.ModelView
{


    public class LandlordModelView<T> : IModelView<LandlordData>
    {
        private IList<LandlordData> _GetAll;
        private LandlordData landlordData;
        private AddressData addressData;
        private string conStr;
        CheckPhone<LandlordData> checkPhone = new CheckPhone<LandlordData>();

        public LandlordModelView()
        {
            _GetAll = GetAll();
            
        }

        public IList<LandlordData> GetAllData { 
            get { return _GetAll; } 
            set { _GetAll = value; }
        }

        public async void DeleteAll()
        {
            await Task.Run(() =>
            {
                conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                string commandStringAddress = "DELETE FROM AddressTable";
                string commandStringLandlord = "DELETE FROM LandlordTable";

                try
                {

                    //step --1
                    SQLiteConnection conn = new SQLiteConnection(conStr);
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
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string commandStringAddress = "DELETE FROM AddressTable WHERE landlord_id = " + id+";";
            string commandStringLandlord = "DELETE FROM LandlordTable WHERE id = " + id+";";
            //string commandString = "DELETE FROM AddressTable, LandlordTable WHERE "
            try
            {
                //step --1
                SQLiteConnection conn = new SQLiteConnection(conStr);
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

        public List<LandlordData> GetAll()
        {

            List<LandlordData> li = new List<LandlordData>();

            string conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string commandStr = "SELECT * FROM LandlordTable INNER JOIN AddressTable ON LandlordTable.id = AddressTable.landlord_id;";

            SQLiteConnection conn = new SQLiteConnection(conStr);
            SQLiteDataAdapter da = new SQLiteDataAdapter(commandStr, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);



            for (int r = 0; r < dt.Rows.Count; r++)
            {
                li.Add(new LandlordData()
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
            return  li;

        }
        public LandlordData GetById(int id)
        {
            LandlordData lld = new LandlordData();
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            string CommandString = "SELECT * FROM LandlordTable WHERE id = "+id+"";
            try
            {
                SQLiteConnection con = new SQLiteConnection(conStr);
                SQLiteDataAdapter Landlordad = new SQLiteDataAdapter(CommandString, con);
                DataTable dt = new DataTable();
                Landlordad.Fill(dt);
                for (int r=0; r<dt.Rows.Count; r++)
                {
                    lld = new LandlordData()
                    {
                        FirstName = dt.Rows[r][1].ToString(),
                        LastName = dt.Rows[r][2].ToString(),
                        Phone = dt.Rows[r][3].ToString(),
                        Email = dt.Rows[r][4].ToString()
                    };
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString());}
            
            return lld;
        }
        
        public void UpdateById(LandlordData item)
        {
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //pass landlord id by item when it's selected
            int landlordId = item.Id;
            
            string CommandStringLandlord = "UPDATE LandlordTable SET FirstName='" + item.FirstName + "', LastName='" + item.LastName + "'" +
                ", email='" + item.Email + "', phone='" + item.Phone + "' WHERE id=" + landlordId + ";";

            string CommandStringAddress = "UPDATE AddressTable SET lineOne='" + item.Address.LineOne + "', lineTwo='" + item.Address.LineTwo + "'" +
                ", postcode='" + item.Address.PostCode + "', contry='" + item.Address.Country + "',city='" + item.Address.City + "'" +
                "WHERE landlord_id=" + landlordId + "; ";


            try
            {
                //Step -- 1
                SQLiteConnection conn = new SQLiteConnection(conStr);
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

        public void Add(LandlordData item)
        {
            //Adding landlord data
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                string commandStrLandlord =
                    "INSERT INTO LandlordTable (firstName, lastName,phone,email) VALUES" +
                    "('" + item.FirstName + "','" + item.LastName + "','" + item.Phone + "','" + item.Email + "');";

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
                int lastIdCount = Convert.ToInt32(checkPhone.GetIdByPhone(item.Phone, "LandlordTable"));
                //int lastIdCount = Convert.ToInt32( GetIdByPhone(item.Phone));
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







        public AddressData GetAddress(LandlordData lld)
        {
            AddressData addressdata = new AddressData();    
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            int landlord_ID = Convert.ToInt32( GetId(lld));
            string commStr = "SELECT * FROM AddressTable WHERE landlord_id= " + landlord_ID + "";

            try
            {
                SQLiteConnection conn = new SQLiteConnection(conStr);
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
        
        //To get the int id by the landlord property.
        public int GetId(LandlordData landlordDataId)
        {
            int id=0;
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string commandid =
                "SELECT id FROM LandlordTable WHERE firstName='" + landlordDataId.FirstName +
                "' AND lastName='" + landlordDataId.LastName + "' AND phone='" + landlordDataId.Phone + "';";
            try
            {
                SQLiteConnection conId = new SQLiteConnection(conStr);
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
