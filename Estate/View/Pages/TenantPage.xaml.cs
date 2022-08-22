using Estate.View.Pages.Classes;
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
            Search searchPage = new Search();
            FrameChange f = new FrameChange(searchPage, TenantFrame);
        }

        private void AddTenantButton_Click(object sender, RoutedEventArgs e)
        {
            AddTenant add = new AddTenant();
            FrameChange f = new FrameChange(add, TenantFrame);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search searchPage = new Search();
            FrameChange f = new FrameChange(searchPage, TenantFrame);
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {
            
            Search s = new Search();
            FrameChange f = new FrameChange(s, TenantFrame);
            s.Asort();
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {
            Search s = new Search();
            FrameChange f = new FrameChange(s, TenantFrame);
            s.Dsort();
        }

        private void btnEditTenant_Click(object sender, RoutedEventArgs e)
        {
            
            Edit EditPage = new Edit();
            FrameChange f = new FrameChange(EditPage, TenantFrame);
        }

        private void btnDeleteTenant_Click(object sender, RoutedEventArgs e)
        {
            
            Delete deletePage = new Delete();
            FrameChange f = new FrameChange(deletePage, TenantFrame);
        }
    }
}
