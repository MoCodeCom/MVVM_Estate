using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Model.Interface
{
    public interface IPropertyData
    {
        public string FullName { get; set; }
        public AddressData Address { get; set; }
        public string Phone { get; set; }
    }
}
