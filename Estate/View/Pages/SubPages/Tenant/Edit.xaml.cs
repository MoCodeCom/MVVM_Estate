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

namespace Estate.View.Pages.SubPages.Tenant
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        TenantModelView<TenantData> ttd = new TenantModelView<TenantData>();
        CheckPhone<TenantData> checkPhone = new CheckPhone<TenantData>();
        private TenantData tenantData;
        AddressData addressData;
        public int tenantIdindt;
        private GetIdByData<TenantData> Getid = new GetIdByData<TenantData>();

        public Edit()
        {
            InitializeComponent();
            DataGridTenantEdit.ItemsSource = ttd.GetAll();
            Clear();
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = ttd.GetAll().Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridTenantEdit.ItemsSource = null;
                DataGridTenantEdit.ItemsSource = filterTenant;
            }
            else
            {
                DataGridTenantEdit.ItemsSource = new TenantModelView<TenantData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void DataGridTenantEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Activate save Button
            btnSave.IsEnabled = true;
            var ItemTenant = DataGridTenantEdit.SelectedItem as TenantData;
            if (ItemTenant != null)
            {
                string NameStr = ItemTenant.FirstName.ToLower();
                var i = ttd.GetAll().Where(x => x.FirstName.ToLower() == NameStr);
                //Get tenant id in database
                tenantIdindt = ttd.GetId(ItemTenant);

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
                tenantData = new TenantData()
                {
                    //Carried the id in the tenantData with the GetId value.
                    Id = tenantIdindt,
                    FirstName = txtFristName.Text,
                    LastName = txtLastName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = addressData

                };

                MessageBoxResult result = MessageBox.Show("Are you sure to update tenant information in system?",
                    "Update", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                switch (result)
                {
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.OK:
                        TenantData check = ttd.GetById(tenantIdindt);

                        // To check the enteries to updated..
                        //if (check.Phone == txtPhone.Text || !lldata.checkPhoneExists(tenantData) &&
                        if (check.Phone == txtPhone.Text || !checkPhone.checkPhoneExists(tenantData, "TenantTable") &&
                           TestContent.IsValidPhone(txtPhone.Text))
                        {
                            ttd.UpdateById(tenantData);
                            DataGridTenantEdit.ItemsSource = ttd.GetAll();
                            Clear();
                            MessageBox.Show("Update data is done.", "Update");
                            btnSave.IsEnabled = false;
                        }
                        else
                        {
                            MessageBox.Show("The phone number is exist already,\n Or it is written in wrong way!", "Warning");
                        }
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
        public bool CheckPhone(TenantData tData)
        {
            return ttd.GetAll().Contains(tData) ? false : true;
        }


    }
}
