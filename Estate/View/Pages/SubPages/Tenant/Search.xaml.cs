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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        TenantModelView<TenantData> Tedata = new TenantModelView<TenantData>();
        public Search()
        {
            InitializeComponent();
            DataGridElement.ItemsSource = new TenantModelView<TenantData>().GetAllData;
        }


        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = Tedata.GetAllData.Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower()) ||
                x.PostCode.ToLower().Contains(tb.Text.ToLower()) ||
                x.Phone.ToLower().Contains(tb.Text.ToLower()) ||
                x.Email.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridElement.ItemsSource = null;
                DataGridElement.ItemsSource = filterTenant;
            }
            else
            {
                DataGridElement.ItemsSource = new TenantModelView<TenantData>().GetAllData;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        public void Dsort()
        {
            var DESCsortGrid = Tedata.GetAllData.OrderByDescending(x => x.FirstName.ToLower());
            DataGridElement.ItemsSource = null;
            DataGridElement.ItemsSource = DESCsortGrid;
        }

        public void Asort()
        {
            var ASCsort = Tedata.GetAllData.OrderBy(x => x.FirstName.ToLower());
            DataGridElement.ItemsSource = null;
            DataGridElement.ItemsSource = ASCsort;
        }
    }
}
