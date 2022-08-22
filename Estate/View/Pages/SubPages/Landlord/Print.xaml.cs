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

namespace Estate.View.Pages.SubPages.Landlord
{
    /// <summary>
    /// Interaction logic for Print.xaml
    /// </summary>
    public partial class Print : Page
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Printbtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            //pd.PrintDocument(DocPrint.DataContext as DocumentPaginator, "Landlords");
        }
    }
}
