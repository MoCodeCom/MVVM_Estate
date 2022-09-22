using Estate.Model.Data;
using Estate.Model.Interface;
using Estate.ModelView;
using Estate.ModelView.Classes;
using Estate.View.Pages.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Estate.View.Pages.SubPages.Property
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        public List<byte[]> ImagesByte = new List<byte[]>()
        {
            new byte[]{ 0},
            new byte[]{ 0},
            new byte[]{ 0},
            new byte[]{ 0}
        };

        public int PropertyId = 0;
        PropertyModelView<PropertyData> Propdata = new PropertyModelView<PropertyData>();
        AddressData addressData = new AddressData();
        PropertyData propertyData = new PropertyData();
        GetLandlordsInfo lli = new GetLandlordsInfo();// to get landlords name in the combobox
        public Edit()
        {
            InitializeComponent();
            DataGridPorpertyEdit.ItemsSource = Propdata.GetAll();
            cbNameOwner.ItemsSource = lli.GetLandlordsName();
        }

        private void DataGridPorpertyEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var ItemProp = DataGridPorpertyEdit.SelectedItem as PropertyData;
            if (ItemProp != null)
            {
                string NameStr = ItemProp.Address.PostCode;
                var i = Propdata.GetAll().Where(x => x.Address.PostCode == NameStr);
                
                foreach (var items in i)
                {
                    PropertyId = items.Id;
                    cbNameOwner.Text = items.OwnerName;
                    txtLineOne.Text = items.Address.LineOne;
                    txtLineTwo.Text = items.Address.LineTwo;
                    txtCountry.Text = items.Address.Country;
                    txtCity.Text = items.Address.City;
                    txtPostCode.Text = items.Address.PostCode;
                    txtPhone.Text = items.Phone;
                    ImagesByte[0] = items.Image_1;
                    ImagesByte[1] = items.Image_2;
                    ImagesByte[2] = items.Image_3;
                    ImagesByte[3] = items.Image_4;

                    break;
                }
            }
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = Propdata.GetAll().Where(x =>
                x.OwnerName.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.PostCode.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridPorpertyEdit.ItemsSource = null;
                DataGridPorpertyEdit.ItemsSource = filterTenant;
            }
            else
            {
                DataGridPorpertyEdit.ItemsSource = new PropertyModelView<PropertyData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void btnImage1_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[0] = imageAsByte;
            MessageBox.Show("Upload is done! ", "Upload New Image");
        }

        private void btnImage2_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[1] = imageAsByte;
            MessageBox.Show("Upload is done! ", "Upload New Image");
        }

        private void btnImage3_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[2] = imageAsByte;
            MessageBox.Show("Upload is done! ", "Upload New Image");
        }

        private void btnImage4_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageAsByte = ImageProcess.UploadByte();
            ImagesByte[3] = imageAsByte;
            MessageBox.Show("Upload is done! ", "Upload New Image");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int propertyId = GetPropertyIdByFullName.OwnerId("PropertyTable", cbNameOwner.Text);
                string newPhone = txtPhone.Text;


                addressData = new AddressData()
                {
                    LineOne = txtLineOne.Text,
                    LineTwo = txtLineTwo.Text,
                    PostCode = txtPostCode.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text

                };
                propertyData = new PropertyData()
                {
                    //Carried the id in the landlordData with the GetId value.
                    Id = PropertyId,
                    OwnerName = cbNameOwner.Text,
                    Phone = txtPhone.Text,
                    Address = addressData,
                    Image_1 = ImagesByte[0],
                    Image_2 = ImagesByte[1],
                    Image_3 = ImagesByte[2],
                    Image_4 = ImagesByte[3],
                    
                };

                MessageBoxResult result = MessageBox.Show("Are you sure to update landlord information in system?",
                    "Update", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                string postcodeStr = propertyData.Address.PostCode.ToString();
               
                switch (result)
                {
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.OK:

                        Propdata.UpdateById(propertyData);

                        DataGridPorpertyEdit.ItemsSource = Propdata.GetAll();
                        Clear();
                        MessageBox.Show("Update data is done.", "Update");
                        
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            Clear();
        }

        private void Clear()
        {
            cbNameOwner.Text = "";
            txtLineOne.Text = "";
            txtLineTwo.Text = "";
            txtPostCode.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            ImagesByte = new List<byte[]>()
            {
                new byte[]{ 0 },
                new byte[]{ 0 },
                new byte[]{ 0 },
                new byte[]{ 0 }
            };
        }
    }
}
