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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
        TenantModelView<TenantData> Tenantdata = new TenantModelView<TenantData>();
        public Delete()
        {
            InitializeComponent();
            DataGridTenant.ItemsSource = new TenantModelView<TenantData>().GetAllData;
        }

        
        

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = Tenantdata.GetAllData.Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower()) ||
                x.PostCode.ToLower().Contains(tb.Text.ToLower()) ||
                x.Phone.ToLower().Contains(tb.Text.ToLower()) ||
                x.Email.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridTenant.ItemsSource = null;
                DataGridTenant.ItemsSource = filterTenant;
            }
            else
            {
                DataGridTenant.ItemsSource = new TenantModelView<TenantData>().GetAllData;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure to delete all landlords details in the system?");
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = DataGridTenant.SelectedItem as TenantData;
                MessageBox.Show(selectedItem.FirstName.ToString() + " will deleted");
                string fullname = (selectedItem.FirstName + selectedItem.LastName).ToString();


                //DataGridTenant.ItemsSource = lldata.DeleteByFullName(fullname);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
