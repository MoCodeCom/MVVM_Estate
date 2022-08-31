using Estate.Model.Data;
using Estate.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using Estate.ModelView.CommandStrings;

namespace Estate.View.Pages.SubPages.Landlord
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        LandlordModelView<LandlordData> lldata = new LandlordModelView<LandlordData>();

        public Search()
        {
            InitializeComponent();
            DataGridLandlord.ItemsSource = lldata.GetAll();
            
        }
        
        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterLandlord = lldata.GetAllData.Where(x => 
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.PostCode.ToLower().Contains(tb.Text.ToLower())||
                x.Phone.ToLower().Contains(tb.Text.ToLower()) || 
                x.Email.ToLower().Contains(tb.Text.ToLower())
                
                );
                DataGridLandlord.ItemsSource = null;
                DataGridLandlord.ItemsSource = filterLandlord;
            }
            else
            {
                DataGridLandlord.ItemsSource = new LandlordModelView<LandlordData>().GetAllData;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        public void Dsort()
        {
            
            
            var DESCsortGrid = lldata.GetAll().OrderByDescending(x => x.FirstName.ToLower());
            DataGridLandlord.ItemsSource = null;
            DataGridLandlord.ItemsSource = DESCsortGrid;
        }

        public void Asort()
        {
            
            var ASCsortGrid = lldata.GetAll().OrderBy(x => x.FirstName.ToLower());
            DataGridLandlord.ItemsSource = null;
            DataGridLandlord.ItemsSource = ASCsortGrid;
        }

        
    }


}
