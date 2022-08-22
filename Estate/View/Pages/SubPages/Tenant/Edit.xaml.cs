using Estate.Model.Data;
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

namespace Estate.View.Pages.SubPages.Tenant
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        TenantModelView<TenantData> Tendata = new TenantModelView<TenantData>();
        public Edit()
        {
            InitializeComponent();
            DataGridTenantEdit.ItemsSource = Tendata.GetAllData;
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = Tendata.GetAllData.Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridTenantEdit.ItemsSource = null;
                DataGridTenantEdit.ItemsSource = filterTenant;
            }
            else
            {
                DataGridTenantEdit.ItemsSource = new LandlordModelView<LandlordData>().GetAllData;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void DataGridTenantEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ItemTenant = DataGridTenantEdit.SelectedItem as TenantData;
            if (ItemTenant != null)
            {
                string NameStr = ItemTenant.FirstName.ToLower();
                var i = Tendata.GetAll().Where(x => x.FirstName.ToLower() == NameStr);
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
    }
}
