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
    }
}
