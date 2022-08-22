using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView.CommandStrings
{
    public class SqliteCommands
    {
        public string SelectAll(string tableName)
        {
            return "SELECT*FROM " + tableName+";";
        }

        public string SelectAllASC(string tableName_1, string tableName_2, string col_1, string col_2,string orderCol)
        {
            return "SELECT*FROM " + tableName_1 + " INNER JOIN " + tableName_2 + " ON " +
                tableName_1 + "." + col_1 + " = " + tableName_2 + "." + col_2 + " ORDER BY " +
                tableName_1 + "." + orderCol + " ASC " + ";"; 
        }

        public string SelectAllDESC(string tableName_1, string tableName_2, string col_1, string col_2, string orderCol)
        {
            return "SELECT*FROM " + tableName_1 + " INNER JOIN " + tableName_2 + " ON " +
                tableName_1 + "." + col_1 + " = " + tableName_2 + "." + col_2 + " ORDER BY " +
                tableName_1 + "." + orderCol + " DESC " + ";";
        }

        public string SelectAllTwoTables(string tableName_1, string tableName_2,string col_1, string col_2)
        {
            return "SELECT*FROM " + tableName_1 + " INNER JOIN " + tableName_2 + " ON " + 
                tableName_1+"."+ col_1 + " = "+ tableName_2+"."+col_2+";";
        }

        public string AddCommand(string tableName,string[] cols, string[] values)
        {
            return "INSERT INTO " + tableName + " " + cols[0] + "," + cols[1] + "," + cols[2] + "," + cols[3] + 
                " VALUES (" + values[0] + "," + values[1] + "," + values[2] + "," + values[3] + ");";
        }
    }
}
