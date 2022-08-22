using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Markup;

namespace Estate.Model.Data
{
    public class MoneyListData
    {
        public int id { get; set; }
        public string tansaction { get; set; }
        public string date { get; set; }
        public string amount { get; set; }

        public string state { get; set; }
        public string issued { get; set; }
        public string paymentMethod { get; set; }
        
    }
}
