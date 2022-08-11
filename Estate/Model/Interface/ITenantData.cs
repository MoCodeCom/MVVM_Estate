using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Model.Interface
{
    public interface ITenantData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AddressData Address { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
