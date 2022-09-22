using Estate.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Estate.Model.Data
{
    public class PropertyData : IPropertyData, INotifyPropertyChanged
    {
        private int _id;
        private string _ownerName;
        private AddressData _address;
        private string _Phone;
        private byte[] _image_1;
        private byte[] _image_2;
        private byte[] _image_3;
        private byte[] _image_4;
        private BitmapSource _bitmapimage_1;
        private BitmapSource _bitmapimage_2;
        private BitmapSource _bitmapimage_3;
        private BitmapSource _bitmapimage_4;
        private Image _get_image_1;
        private Image _get_image_2;
        private Image _get_image_3;
        private Image _get_image_4;
        private int _owner_id;
        private int _tenant_id;

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

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
                OnPropertyChanged(nameof(_id));
            }
        }



        public string OwnerName 
        {
            get { return _ownerName; }
            set 
            {
                if (_ownerName != value)
                {
                    _ownerName = value;
                }
                OnPropertyChanged(nameof(_ownerName));
            } 
        }

        public AddressData Address 
        {
            get { return _address; } 
            set 
            {
                if (_address != value)
                {
                    _address = value;
                }
                OnPropertyChanged(nameof(_address));
            } 
        }
        public BitmapSource Bitmapimage_1
        {
            get { return _bitmapimage_1; }
            set
            {
                if (_bitmapimage_1 != value)
                {
                    _bitmapimage_1 = value;
                }
                OnPropertyChanged(nameof(_bitmapimage_1));
            }
        }

        public BitmapSource Bitmapimage_2
        {
            get { return _bitmapimage_2; }
            set
            {
                if (_bitmapimage_2 != value)
                {
                    _bitmapimage_2 = value;
                }
                OnPropertyChanged(nameof(_bitmapimage_2));
            }
        }

        public BitmapSource Bitmapimage_3
        {
            get { return _bitmapimage_3; }
            set
            {
                if (_bitmapimage_3 != value)
                {
                    _bitmapimage_3 = value;
                }
                OnPropertyChanged(nameof(_bitmapimage_3));
            }
        }

        public BitmapSource Bitmapimage_4
        {
            get { return _bitmapimage_4; }
            set
            {
                if (_bitmapimage_4 != value)
                {
                    _bitmapimage_4 = value;
                }
                OnPropertyChanged(nameof(_bitmapimage_4));
            }
        }

        public byte[] Image_1
        {
            get { return _image_1; }
            set
            {
                if (_image_1 != value)
                {
                    _image_1 = value;
                }
                OnPropertyChanged(nameof(_image_1));
            }
        }

        public byte[] Image_2
        {
            get { return _image_2; }
            set
            {
                if (_image_2 != value)
                {
                    _image_2 = value;
                }
                OnPropertyChanged(nameof(_image_2));
            }
        }

        public byte[] Image_3
        {
            get { return _image_3; }
            set
            {
                if (_image_3 != value)
                {
                    _image_3 = value;
                }
                OnPropertyChanged(nameof(_image_3));
            }
        }

        public byte[] Image_4
        {
            get { return _image_4; }
            set
            {
                if (_image_4 != value)
                {
                    _image_4 = value;
                }
                OnPropertyChanged(nameof(_image_4));
            }
        }

        public Image Get_Image_1
        {
            get { return _get_image_1; }
            set
            {
                if (_get_image_1 != value)
                {
                    _get_image_1 = value;
                }
                OnPropertyChanged(nameof(_get_image_1));
            }
        }

        public int Owner_id
        {
            get { return _owner_id; }
            set
            {
                if (_owner_id != value)
                {
                    _owner_id = value;
                }
                OnPropertyChanged(nameof(_owner_id));
            }
        }

        public int Tenant_id
        {
            get { return _tenant_id; }
            set
            {
                if (_tenant_id != value)
                {
                    _tenant_id = value;
                }
                OnPropertyChanged(nameof(_tenant_id));
            }
        }

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
