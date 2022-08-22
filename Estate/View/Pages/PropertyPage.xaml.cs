using Estate.View.Pages.Classes;
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
            Search s = new Search();
            FrameChange f = new FrameChange(s, PropertyFrame);
        }

        private void btnAddPorperty_Click(object sender, RoutedEventArgs e)
        {
            AddProperty add = new AddProperty();
            FrameChange f = new FrameChange(add, PropertyFrame);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
           
            Search s = new Search();
            FrameChange f = new FrameChange(s, PropertyFrame);
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {
            Search s = new Search();
            FrameChange f = new FrameChange(s, PropertyFrame);
            s.Asort();
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {
            Search s = new Search();
            FrameChange f = new FrameChange(s, PropertyFrame);
            s.Dsort();
        }

        private void btnEditPorperty_Click(object sender, RoutedEventArgs e)
        {
            Edit EditPage = new Edit();
            FrameChange f = new FrameChange(EditPage, PropertyFrame);
        }

        private void btnDeleteProperty_Click(object sender, RoutedEventArgs e)
        {
            
            Delete DeletePage = new Delete();
            FrameChange f = new FrameChange(DeletePage, PropertyFrame);
        }
    }
}
