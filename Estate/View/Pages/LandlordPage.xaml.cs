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
using Estate.View.Pages.SubPages.Landlord;
using Estate.View.UserControls;

namespace Estate.Pages
{
    /// <summary>
    /// Interaction logic for LandlordPage.xaml
    /// </summary>
    public partial class LandlordPage : Page
    {
        public LandlordPage()
        {
            InitializeComponent();
            InitialPage();
        }

        public void InitialPage()
        {
            if (LandlordFrame.Content != null)
            {
                LandlordFrame.Content = null;
            }
            Search searchPage = new Search();
            LandlordFrame.Content = searchPage;
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AddLandlordButton_Click(object sender, RoutedEventArgs e)
        {
            if (LandlordFrame.Content != null)
            {
                LandlordFrame.Content = null;
            }
            Add addPage = new Add();
            LandlordFrame.Content = addPage;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (LandlordFrame.Content != null)
            {
                LandlordFrame.Content = null;
            }
            Search searchPage = new Search();
            LandlordFrame.Content = searchPage;
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {
            if(LandlordFrame.Content != null)
            {
                LandlordFrame.Content = null;
            }
            Search s = new Search();
            LandlordFrame.Content = s;
            s.Asort();
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {
            if (LandlordFrame.Content != null)
            {
                LandlordFrame.Content = null;
            }
            Search s = new Search();
            LandlordFrame.Content = s;
            s.Dsort();
        }

        private void EditLandlordButton_Click(object sender, RoutedEventArgs e)
        {
            if (LandlordFrame.Content != null)
            {
                LandlordFrame.Content = null;
            }
            Edit editPage = new Edit();
            LandlordFrame.Content = editPage; 
        }

        
    }
}
