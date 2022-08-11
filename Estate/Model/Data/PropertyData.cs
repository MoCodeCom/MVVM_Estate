using Estate.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Estate.Model.Data
{
    public class PropertyData : IPropertyData, INotifyPropertyChanged
    {
        private string _FullName;
        private string _LineOne;
        private string _LineTwo;
        private string _PostCode;
        private string _City;
        private string _Country;
        private string _Phone;

        public PropertyData()
        {
            /*
            _FullName = FullName;
            _LineOne = LineOne;
            _LineTwo = LineTwo;
            _PostCode = PostCode;
            _City = City;
            _Country = Country;
            _Phone = Phone;
            */
        }


        public string FullName { get; set; }
        public AddressData Address { get; set; }
        public string LineOne { 
            get { return _LineOne; }
            set {
                if (_LineOne != value)
                {
                    _LineOne = value;
                }
                OnPropertyChanged(nameof(_LineOne));
            
            } } 
        public string LineTwo {
            get { return _LineTwo; } 
            set {
                if (_LineTwo != value)
                {
                    _LineTwo = value;
                }
                OnPropertyChanged(nameof(_LineTwo));
            } }
        public string PostCode { 
            get { return _PostCode; }
            set {
                if (_PostCode != value)
                {
                    _PostCode = value;
                }
                OnPropertyChanged(nameof(_PostCode));
            
            } }
        public string City { 
            get { return _City; }
            set { 
                if (_City != value)
                {
                    _City = value;
                }
                OnPropertyChanged(nameof(_City));
            }
        }
        public string Country {
            get { return _Country; }
            set {
                if (_Country != value)
                {
                    _Country = value;
                }
                OnPropertyChanged(nameof(_Country));
            } }

        public string Phone {
            get { return _Phone; }
            set {
                if (_Phone != value)
                {
                    _Phone = value;
                }
            } 
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
