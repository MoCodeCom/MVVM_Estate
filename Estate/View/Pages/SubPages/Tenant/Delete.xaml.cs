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
        private TenantData tenantData;
        TenantModelView<TenantData> ttd = new TenantModelView<TenantData>();
        public Delete()
        {
            InitializeComponent();
            DataGridTenant.ItemsSource = new TenantModelView<TenantData>().GetAll();
        }


        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = ttd.GetAll().Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.PostCode.ToLower().Contains(tb.Text.ToLower()) ||
                x.Phone.ToLower().Contains(tb.Text.ToLower()) ||
                x.Email.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridTenant.ItemsSource = null;
                DataGridTenant.ItemsSource = filterTenant;
            }
            else
            {
                DataGridTenant.ItemsSource = new TenantModelView<TenantData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Are you sure to delete all Tenants details from the system?", "Delete All",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            try
            {
                switch (Result)
                {
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.OK:
                        //To delete all details form database.
                        ttd.DeleteAll();

                        MessageBox.Show("Delete is done.");
                        DataGridTenant.ItemsSource = new TenantModelView<TenantData>().GetAll();
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

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = DataGridTenant.SelectedItem as TenantData;
                MessageBoxResult Result = MessageBox.Show(selectedItem.FirstName.ToString() + " will delete from the system.", "Delete",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                switch (Result)
                {
                    case MessageBoxResult.None:

                        break;
                    case MessageBoxResult.OK:
                        //To get the item's id.
                        //int SeletctedItemId = Convert.ToInt32( lldata.GetId(selectedItem));
                        int SeletctedItemId = Convert.ToInt32(ttd.GetId(selectedItem));
                        //To delete item by id.
                        ttd.DeleteById(SeletctedItemId);

                        MessageBox.Show("Delete is done.");
                        DataGridTenant.ItemsSource = new TenantModelView<TenantData>().GetAll();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
