using Estate.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Model.Data
{
    public class RecivableData:IRecivable, INotifyPropertyChanged
    {

        private int _id;
        private string _tansaction;
        private string _date;
        private string _amount;
        private string _state;
        private string _issued;
        private string _paymentMethod;

        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
                OnPropertyChanged(nameof(id));
            }
        }
        public string tansaction
        {
            get { return _tansaction; }
            set
            {
                if (_tansaction != value)
                {
                    _tansaction = value;
                }
                OnPropertyChanged(nameof(tansaction));
            }
        }
        public string date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                }
                OnPropertyChanged(nameof(date));
            }
        }
        public string amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                }
                OnPropertyChanged(nameof(amount));
            }
        }
        public string state
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                }
                OnPropertyChanged(nameof(state));
            }
        }
        public string issued
        {
            get { return _issued; }
            set
            {
                if (_issued != value)
                {
                    _issued = value;
                }
                OnPropertyChanged(nameof(issued));
            }
        }
        public string paymentMethod
        {
            get { return _paymentMethod; }
            set
            {
                if (_paymentMethod != value)
                {
                    _paymentMethod = value;
                }
                OnPropertyChanged(nameof(paymentMethod));
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
