using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Model.Interface
{
    public interface IPayment
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
