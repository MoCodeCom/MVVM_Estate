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

namespace Estate.ModelView
{


    public class LandlordModelView<T> : IModelView<LandlordData>
    {
        private IList<LandlordData> _GetAll;
        //private LandlordData landlordData;
        //private AddressData addressData;
        private string conStr;

        public LandlordModelView()
        {
            _GetAll = GetAllLandlords();
        }

        public IList<LandlordData> GetAllData { 
            get { return _GetAll; } 
            set { _GetAll = value; }
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<LandlordData> DeleteByFullName(string fullName)
        {
            

            List<LandlordData> li = GetAllData.ToList<LandlordData>();
            GetAllData.Remove(li.FirstOrDefault<LandlordData>(x => x.FirstName + x.LastName == fullName));
            return li;
        }

        public List<LandlordData> GetAll()
        {
            throw new NotImplementedException();

        }
        public LandlordData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(string id)
        {
            //UpdateByIdLandlord(id, landlordData, addressData);
        }

        public int GetId(LandlordData landlordDataId)
        {
            int? id = 0;
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string commandid = "SELECT id FROM LandlordTable WHERE FirstName='"+landlordDataId.FirstName+"' AND LastName='"+landlordDataId.LastName+"'";
            try
            {
                SQLiteConnection conId = new SQLiteConnection(conStr);
                SQLiteDataAdapter ad = new SQLiteDataAdapter(commandid, conId);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                for (int i =0;i<dt.Rows.Count ;i++)
                {
                    id = Convert.ToInt32(dt.Rows[i][0]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
            return Convert.ToInt32(id);
        }

        public void UpdateByIdLandlord(string id, LandlordData landlordData, AddressData addressData)
        {
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string CommandStringLandlord = "UPDATE LandlordTable SET FirstName='"+landlordData.FirstName+"', LastName='"+landlordData.LastName+"'" +
                ", email='"+landlordData.Email+"', phone='"+landlordData.Phone+"' WHERE phone='" + id + "' ";

            int landlordId = GetId(landlordData);
            MessageBox.Show(landlordId.ToString());

            string CommandStringAddress = "UPDATE AddressTable SET lineOne='" + addressData.LineOne + "', lineTwo='" + addressData.LineTwo + "'" +
                ", postcode='" + addressData.PostCode + "', contry='" + addressData.Country + "',city='"+addressData.City+"' " +
                "WHERE landlord_id="+landlordId+" ";

            try
            {
                SQLiteConnection conLandlord = new SQLiteConnection(conStr);
                SQLiteDataAdapter daLandlord = new SQLiteDataAdapter();
                conLandlord.Open();

                daLandlord.UpdateCommand = new SQLiteCommand(CommandStringLandlord, conLandlord);
                daLandlord.UpdateCommand.ExecuteNonQuery();

                conLandlord.Close();
            }
            catch (Exception e){ MessageBox.Show(e.Message);}

            try
            {
                SQLiteConnection conAddress = new SQLiteConnection(conStr);
                SQLiteDataAdapter daAddress = new SQLiteDataAdapter(CommandStringAddress,conAddress);
                conAddress.Open();

                daAddress.UpdateCommand = new SQLiteCommand(CommandStringAddress,conAddress);
                daAddress.UpdateCommand.ExecuteNonQuery();
                
                conAddress.Close();

            }catch (Exception e) { MessageBox.Show(e.Message); }
            
        }

        public List<LandlordData> GetAll_1(string id= "Default",string sorting="Default")
        {
            List<LandlordData> li = new List<LandlordData>();

            string conStr = ConfigurationManager.ConnectionStrings[id].ConnectionString;
            string commandStr;
            if (sorting == "ASC")
            {
                commandStr = new SqliteCommands()
                    .SelectAllASC("LandlordTable","AddressTable","id","landlord_id","firstName" );
            }else if (sorting == "DESC")
            {
                commandStr = new SqliteCommands()
                    .SelectAllDESC("LandlordTable", "AddressTable", "id", "landlord_id", "firstName");
            }
            else
            {
                commandStr = new SqliteCommands().SelectAllTwoTables("LandlordTable","AddressTable","id","landlordTable");
            }

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
            return li;
        }

        public List<LandlordData> GetAllLandlords(string id = "Default")
        {
            List<LandlordData> li = new List<LandlordData>();

            string conStr = ConfigurationManager.ConnectionStrings[id].ConnectionString;
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
            return li;
        }

        public void Add()
        {
            string conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            string commandStr =
                "INSERT INTO landlordTable (firstName, lastName,phone,email) VALUES (@fName,@lName,@phone,@email)";
            SQLiteConnection con = new SQLiteConnection(conStr);
            SQLiteDataAdapter da = new SQLiteDataAdapter(commandStr, con);

            //da.SelectCommand.Parameters.AddWithValue("@fName", );
            da.InsertCommand = new SQLiteCommand(commandStr, con);
        }

        public void Add_1(LandlordData landlordData, AddressData addressData)
        {
            string conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            
            string commandLandlordStr =
                "INSERT INTO LandlordTable (firstName, lastName,phone,email) " +
                "VALUES ('"+landlordData.FirstName+"','"+landlordData.LastName+"','"+landlordData.Phone+"','"+landlordData.Email+"')";
            string commandlandlordid = "SELECT id FROM LandlordTable WHERE firstName ='"+landlordData.FirstName+"';";
            DataTable dt = new DataTable();
            int? landlordid = null;
            try
            {
                SQLiteConnection conLandlord = new SQLiteConnection(conStr);
                SQLiteDataAdapter daLandlord = new SQLiteDataAdapter(commandLandlordStr, conLandlord);

                conLandlord.Open();
                daLandlord.InsertCommand = new SQLiteCommand(commandLandlordStr, conLandlord);
                daLandlord.InsertCommand.ExecuteNonQuery();

                daLandlord.SelectCommand = new SQLiteCommand(commandlandlordid, conLandlord);
                daLandlord.Fill(dt);
                landlordid = Convert.ToInt32(dt.Rows[0][0].ToString());

                conLandlord.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            string commandAddressStr =
               "INSERT INTO AddressTable (lineOne, lineTwo, postcode, city, contry, landlord_id)" +
               " VALUES ('" + addressData.LineOne + "','" + addressData.LineTwo + "','" + addressData.PostCode + "','" + addressData.City + "','" + addressData.Country + "'," + landlordid + ");";

            try
            {
                SQLiteConnection conAddress = new SQLiteConnection(conStr);
                SQLiteDataAdapter daAddress = new SQLiteDataAdapter(commandAddressStr, conAddress);
                conAddress.Open();
                daAddress.InsertCommand = new SQLiteCommand(commandAddressStr, conAddress);
                daAddress.InsertCommand.ExecuteNonQuery();
                conAddress.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }
    }














    /*
    public class LandlordModelView<T> : IModelView<LandlordData>
    {
        private ObservableCollection<LandlordData> _GetAll;

        public LandlordModelView()
        {

        }




        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public  ObservableCollection<LandlordData> GetAll()
        {
            ObservableCollection<LandlordData> li = new ObservableCollection<LandlordData>();
            li.Add(new LandlordData()
            {
                FirstName = "Mohammed",
                LastName = "Alfadhel",
                
                Address = new AddressData()
                    { LineOne = "73 conybere", LineTwo = "Higate",
                        PostCode = "B12 0YL", Country = "UnitedKingdom" },
                PostCode = "B12 0YL",
                Email = "mjmdell@gmial.com",
                Phone = "07460726920"
            }) ;

            li.Add(new LandlordData()
                {
                    FirstName = "Hasan",
                    LastName = "Alfadhel",
                    Address = new AddressData()
                    { LineOne = "73 conybere", LineTwo = "Higate", 
                        PostCode = "B18 0YL", Country = "UnitedKingdom" },
                    PostCode = "B18 0YL",
                    Email = "hasandell@gmial.com",
                    Phone = "07460726930"
                });

            li.Add(new LandlordData()
                    {
                        FirstName = "Ahmed",
                        LastName = "Alfadhel",
                        Address = new AddressData()
                        { LineOne = "73 conybere", LineTwo = "Higate", 
                            PostCode = "B32 0YL", Country = "UnitedKingdom" },
                        PostCode = "B32 0YL",
                        Email = "ahmeddell@gmial.com",
                        Phone = "07460782920"
                    });

            li.Add(new LandlordData()
                    {
                        FirstName = "Rasha",
                        LastName = "Almohy",
                        Address = new AddressData()
                        { LineOne = "73 conybere", LineTwo = "Higate", 
                            PostCode = "B1 0YL", Country = "UnitedKingdom" },
                        PostCode = "B1 0YL",
                        Email = "rashaell@gmial.com",
                        Phone = "07460726925"
                    });


            return li;
        }

        public LandlordData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
    */


}
