using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.ModelView.Classes
{
    public class ConnectionStr
    {
        private string _conStr;
        public ConnectionStr()
        {
            _conStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString; ;
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
