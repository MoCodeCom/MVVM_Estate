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
using Estate.View.Pages.Classes;
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
            Search searchPage = new Search();
            FrameChange f = new FrameChange(searchPage, LandlordFrame);
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AddLandlordButton_Click(object sender, RoutedEventArgs e)
        {
            
            Add addPage = new Add();
            FrameChange f = new FrameChange(addPage, LandlordFrame);

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            Search searchPage = new Search();
            FrameChange f = new FrameChange(searchPage, LandlordFrame);
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {

            Search s = new Search();
            FrameChange f = new FrameChange(s, LandlordFrame);
            s.Asort();
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {

            Search s = new Search();
            FrameChange f = new FrameChange(s, LandlordFrame);
            s.Dsort();
        }

        private void EditLandlordButton_Click(object sender, RoutedEventArgs e)
        {

            Edit editPage = new Edit();
            FrameChange f = new FrameChange(editPage, LandlordFrame);
        }

        private void DeleteLandlordButton_Click(object sender, RoutedEventArgs e)
        {

            Delete DeletePage = new Delete();
            FrameChange f = new FrameChange(DeletePage, LandlordFrame);

        }

        private void PrintWeeklyLandlordButton_Click(object sender, RoutedEventArgs e)
        {

            Print PrintPage = new Print();
            FrameChange f = new FrameChange(PrintPage, LandlordFrame);


        }
    }
}
