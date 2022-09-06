using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Estate.ModelView.Classes
{
    public  class ConnectionStr
    {
        private string _conStr;
        public ConnectionStr()
        {
            try
            {
                _conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        public string conStr 
        {
            get 
            { 
                return _conStr; 
            }
            set 
            { 
                _conStr = value; 
            }
        }
    }
}
