using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Model.Interface
{
    public interface IPropertyData
    {
        public int Id { get; set; } 
        public string OwnerName { get; set; }
        public AddressData Address { get; set; }
        public byte[] Image_1 { get; set; }
        public byte[] Image_2 { get; set; }
        public byte[] Image_3 { get; set; }
        public byte[] Image_4 { get; set; }
        public int Owner_id { get; set; }
        public string Phone { get; set; }
    }
}
