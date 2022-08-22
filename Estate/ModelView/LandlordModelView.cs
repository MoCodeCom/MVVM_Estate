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

        public void UpdateById(int id)
        {
            throw new NotImplementedException();
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
        }

        public void Add_1(LandlordData landlordData)
        {
            string conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            string commandStr =
                "INSERT INTO landlordTable (firstName, lastName,phone,email, lineOne, lineTwo, postcode, city, contry) " +
                "VALUES (@fName,@lName,@phone,@email,@lineone,@linetwo,@postcode,@city,@contry)";
            SQLiteConnection con = new SQLiteConnection(conStr);
            SQLiteDataAdapter da = new SQLiteDataAdapter(commandStr, con);

            da.SelectCommand.Parameters.AddWithValue("@fName", landlordData.FirstName);
            da.SelectCommand.Parameters.AddWithValue("@lName", landlordData.LastName);
            da.SelectCommand.Parameters.AddWithValue("@phone", landlordData.Phone);
            da.SelectCommand.Parameters.AddWithValue("@email", landlordData.Email);
            da.SelectCommand.Parameters.AddWithValue("@lineone", landlordData.Address.LineOne);
            da.SelectCommand.Parameters.AddWithValue("@linetwo", landlordData.Address.LineTwo);
            da.SelectCommand.Parameters.AddWithValue("@postcode", landlordData.Address.PostCode);
            da.SelectCommand.Parameters.AddWithValue("@city", landlordData.Address.City);
            da.SelectCommand.Parameters.AddWithValue("@contry", landlordData.Address.Country);

            
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
