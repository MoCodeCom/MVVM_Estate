using Estate.View.Pages.SubPages.Tenant;
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

namespace Estate.Pages
{
    /// <summary>
    /// Interaction logic for TenantPage.xaml
    /// </summary>
    public partial class TenantPage : Page
    {
        public TenantPage()
        {
            InitializeComponent();
            InitialPage();
        }

        public void InitialPage()
        {
            if (TenantFrame.Content != null)
            {
                TenantFrame.Content = null;
            }
            Search searchPage = new Search();
            TenantFrame.Content = searchPage;
        }

        private void AddTenantButton_Click(object sender, RoutedEventArgs e)
        {
            if (TenantFrame != null)
            {
                TenantFrame.Content = null;
            }

            AddTenant add = new AddTenant();
            TenantFrame.Content = add;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (TenantFrame.Content != null)
            {
                TenantFrame.Content = null;
            }
            Search searchPage = new Search();
            TenantFrame.Content = searchPage;
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {
            if (TenantFrame.Content != null)
            {
                TenantFrame.Content = null;
            }
            Search s = new Search();
            TenantFrame.Content = s;
            s.Asort();
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {
            if (TenantFrame.Content != null)
            {
                TenantFrame.Content = null;
            }
            Search s = new Search();
            TenantFrame.Content = s;
            s.Dsort();
        }
    }
}
