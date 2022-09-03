using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate
{
    internal class Garbage
    {
    }
    //adding function raplced after update add function.
    /*

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
     */

    //UpdateByIdLandlord class replaced with UpdateById with some arrangements.
    /*
       public void UpdateByIdLandlord(string id, LandlordData landlordData, AddressData addressData)
       {
           int landlordId = GetId(landlordData);

           conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
           string CommandStringLandlord = "UPDATE LandlordTable SET FirstName='" + landlordData.FirstName + "', LastName='" + landlordData.LastName + "'" +
               ", email='" + landlordData.Email + "', phone='" + landlordData.Phone + "' WHERE id=" + landlordId + ";";

           string CommandStringAddress = "UPDATE AddressTable SET lineOne='" + addressData.LineOne + "', lineTwo='" + addressData.LineTwo + "'" +
               ", postcode='" + addressData.PostCode + "', contry='" + addressData.Country + "',city='" + addressData.City + "'" +
               "WHERE landlord_id=" + landlordId + "; ";

           try
           {
               SQLiteConnection conAddress = new SQLiteConnection(conStr);
               SQLiteDataAdapter daAddress = new SQLiteDataAdapter(CommandStringAddress, conAddress);
               conAddress.Open();

               daAddress.UpdateCommand = new SQLiteCommand(CommandStringAddress, conAddress);
               daAddress.UpdateCommand.ExecuteNonQuery();

               conAddress.Close();

           }
           catch (Exception e) { MessageBox.Show(e.Message); }

           try
           {
               SQLiteConnection conLandlord = new SQLiteConnection(conStr);
               SQLiteDataAdapter daLandlord = new SQLiteDataAdapter();
               conLandlord.Open();

               daLandlord.UpdateCommand = new SQLiteCommand(CommandStringLandlord, conLandlord);
               daLandlord.UpdateCommand.ExecuteNonQuery();

               conLandlord.Close();
           }
           catch (Exception e) { MessageBox.Show(e.Message); }
           MessageBox.Show("Update is done.");
       }

       */
    //
    //In adding xaml file to sorting data that replced with sorting just in grid rather than sorting according to cshrp code.

    //var ASCsortGrid = lldata.GetAll_1("Default", "DESC");
    //var DESCsortGrid = lldata.GetAll_1("Default", "ASC");

    //the csharp code is
    /*
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
     */

    /*
        public int GetLastId()
        {
            int idCount = 0;
            conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string CommandString = "SELECT id FROM LandlordTable ORDER BY id DESC LIMIT 1;";
            try
            {
                SQLiteConnection conn = new SQLiteConnection(conStr);
                SQLiteDataAdapter adId = new SQLiteDataAdapter(CommandString, conn);
                DataTable dt = new DataTable();

                adId.Fill(dt);
                idCount = Convert.ToInt32(dt.Rows[0][0]);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return idCount;
        }*/

    /*
public int GetIdByPhone(string phoneStr)
{
    int id = 0;
    conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
    string commandid =
        "SELECT id FROM LandlordTable WHERE phone='" + phoneStr + "';";
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
}*/

    //To check whether the Landlord property is exist already?
    /*
    public bool checkPhoneExists(LandlordData lld)
    {
        bool result = false;
        conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        string CommandString = "SELECT * FROM LandlordTable WHERE phone = '" + lld.Phone + "'";
        try
        {

            SQLiteConnection con = new SQLiteConnection(conStr);
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
    */

    //To get the int id by the landlord property.
    /*
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

    */
}
