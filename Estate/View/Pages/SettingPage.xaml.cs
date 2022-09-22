using Estate.View.Pages.Classes;
using Estate.View.Pages.SubPages.Landlord;
using Estate.View.Pages.SubPages.Sitting;
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
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private void btnDefaultImage_Click(object sender, RoutedEventArgs e)
        {
            DefaultPicture DefaultPicturePage = new DefaultPicture();
            FrameChange f = new FrameChange(DefaultPicturePage, LandlordFrame);
        }
    }
}
