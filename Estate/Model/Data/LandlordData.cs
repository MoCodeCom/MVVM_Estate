using Estate.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Model.Data
{
    public class LandlordData : ILandlordData, INotifyPropertyChanged
    {
        private int _id;
        private string _FirstName;
        private string _LastName;
        private AddressData _Address;
        private string _Phone;
        private string _Email;

        public string FirstName {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName {
            get { return _LastName; }
            set
            {
                _LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        
        public AddressData Address {
            get { return _Address; }
            set
            {
                _Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Phone {
            get { return _Phone; }
            set
            {
                _Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public string Email {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public int Id 
        { 
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
