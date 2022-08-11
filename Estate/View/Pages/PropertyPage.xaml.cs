using Estate.View.Pages.SubPages.Property;
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
    /// Interaction logic for PropertyPage.xaml
    /// </summary>
    public partial class PropertyPage : Page
    {
        public PropertyPage()
        {
            InitializeComponent();
            initialPage();
        }

        private void initialPage()
        {
            if (PropertyFrame != null)
            {
                PropertyFrame.Content = null;
            }
            Search s = new Search();
            PropertyFrame.Content = s;
        }

        private void btnAddPorperty_Click(object sender, RoutedEventArgs e)
        {
            if (PropertyFrame != null)
            {
                PropertyFrame.Content = null;
            }
            AddProperty add = new AddProperty();
            PropertyFrame.Content = add;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (PropertyFrame != null)
            {
                PropertyFrame.Content = null;
            }
            Search s = new Search();
            PropertyFrame.Content = s;
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {
            if (PropertyFrame.Content != null)
            {
                PropertyFrame.Content = null;
            }
            Search s = new Search();
            PropertyFrame.Content = s;
            s.Asort();
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {
            if (PropertyFrame.Content != null)
            {
                PropertyFrame.Content = null;
            }
            Search s = new Search();
            PropertyFrame.Content = s;
            s.Dsort();
        }
    }
}
