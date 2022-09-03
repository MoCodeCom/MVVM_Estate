using Estate.Model.Data;
using Estate.Model.Interface;
using Estate.ModelView;
using Estate.ModelView.Classes;
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
        CheckPhone<LandlordData> checkPhone = new CheckPhone<LandlordData>();
        private LandlordData landlordData;
        AddressData addressData;
        public int landlordIdindt;
        private GetIdByData<LandlordData> Getid= new GetIdByData<LandlordData>();
       
        public Edit()
        {
            InitializeComponent();
            DataGridLandlordEdit.ItemsSource = lldata.GetAll();
            Clear();
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterLandlord = lldata.GetAll().Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower()) 

                );
                DataGridLandlordEdit.ItemsSource = null;
                DataGridLandlordEdit.ItemsSource = filterLandlord;
            }
            else
            {
                DataGridLandlordEdit.ItemsSource = new LandlordModelView<LandlordData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void DataGridLandlordEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Activate save Button
            btnSave.IsEnabled = true;
            var ItemLandlord = DataGridLandlordEdit.SelectedItem as LandlordData;
            if (ItemLandlord != null)
            {
                string NameStr = ItemLandlord.FirstName.ToLower();
                var i = lldata.GetAll().Where(x => x.FirstName.ToLower() == NameStr);
                //Get landlord id in database
                landlordIdindt = lldata.GetId(ItemLandlord);

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
            try
            {
                string newPhone = txtPhone.Text;

                
                addressData = new AddressData()
                {
                    LineOne = txtLineOne.Text,
                    LineTwo = txtLineTwo.Text,
                    PostCode = txtPostCode.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text

                };
                landlordData = new LandlordData()
                {
                    //Carried the id in the landlordData with the GetId value.
                    Id = landlordIdindt,
                    FirstName = txtFristName.Text,
                    LastName = txtLastName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = addressData

                };
                
                MessageBoxResult result = MessageBox.Show("Are you sure to update landlord information in system?",
                    "Update",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.OK:
                        LandlordData check = lldata.GetById(landlordIdindt);
                        
                        // To check the enteries to updated..
                        //if (check.Phone == txtPhone.Text || !lldata.checkPhoneExists(landlordData) &&
                        if(check.Phone == txtPhone.Text || !checkPhone.checkPhoneExists(landlordData, "LandlordTable") &&
                           TestContent.IsValidPhone(txtPhone.Text))
                        {
                            lldata.UpdateById(landlordData);
                            DataGridLandlordEdit.ItemsSource = lldata.GetAll();
                            Clear();
                            MessageBox.Show("Update data is done.", "Update");
                            btnSave.IsEnabled = false;
                        }
                        else
                        {
                            MessageBox.Show("The phone number is exist already,\n Or it is written in wrong way!","Warning");
                        }
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        break;
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        public bool CheckPhone(LandlordData lData)
        {
            return lldata.GetAll().Contains(lData) ? false : true;
        }
    }
}
