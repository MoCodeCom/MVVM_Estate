using Estate.Model.Data;
using Estate.Model.Interface;
using Estate.ModelView;
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

namespace Estate.View.Pages.SubPages.Landlord
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        LandlordModelView<LandlordData> lldata = new LandlordModelView<LandlordData>();
        LandlordData landlordData;
        AddressData addressData;
        
        public Edit()
        {
            InitializeComponent();
            DataGridLandlordEdit.ItemsSource = lldata.GetAllData;
            Clear();
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterLandlord = lldata.GetAllData.Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower()) 

                );
                DataGridLandlordEdit.ItemsSource = null;
                DataGridLandlordEdit.ItemsSource = filterLandlord;
            }
            else
            {
                DataGridLandlordEdit.ItemsSource = new LandlordModelView<LandlordData>().GetAllData;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void DataGridLandlordEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ItemLandlord = DataGridLandlordEdit.SelectedItem as LandlordData;
            if (ItemLandlord != null)
            {
                string NameStr = ItemLandlord.FirstName.ToLower();
                var i = lldata.GetAllData.Where(x => x.FirstName.ToLower() == NameStr);
                foreach (var items in i)
                {
                    txtFristName.Text = items.FirstName;
                    txtLastName.Text = items.LastName;
                    txtLineOne.Text = items.Address.LineOne;
                    txtLineTwo.Text = items.Address.LineTwo;
                    txtCountry.Text = items.Address.Country;
                    txtCity.Text = items.Address.City;
                    txtPostCode.Text = items.Address.PostCode;
                    txtPhone.Text = items.Phone;
                    txtEmail.Text = items.Email;
                    break;
                }
            }
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            string id = txtPhone.Text;
            landlordData = new LandlordData()
            {
                FirstName = txtFristName.Text,
                LastName = txtLastName.Text,
                Phone = txtLastName.Text,
                Email = txtEmail.Text
            };

            addressData = new AddressData()
            {
                LineOne = txtLineOne.Text,
                LineTwo = txtLineTwo.Text,
                PostCode = txtPostCode.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,

            };

            lldata.UpdateByIdLandlord(id,landlordData,addressData);
            MessageBox.Show("update is done!");
            

            /*
            landlordData = new LandlordData()
            {
                FirstName = txtFristName.Text,
                LastName = txtLastName.Text,
                Phone = txtLastName.Text,
                Email = txtEmail.Text
            };

            int i = Convert.ToInt32(lldata.GetId(landlordData));
            MessageBox.Show(i.ToString());

            */
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtFristName.Text = "";
            txtLastName.Text = "";
            txtLineOne.Text = "";
            txtLineTwo.Text = "";
            txtPostCode.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

        }
    }
}
