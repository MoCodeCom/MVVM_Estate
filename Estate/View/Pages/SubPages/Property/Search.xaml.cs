using Estate.Model.Data;
using Estate.ModelView;
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

namespace Estate.View.Pages.SubPages.Property
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        PropertyModelView<PropertyData> Propdata = new PropertyModelView<PropertyData>();
        public Search()
        {
            InitializeComponent();
            DataGridElement.ItemsSource = new PropertyModelView<PropertyData>().GetAll();
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterProperty = Propdata.GetAll().Where(x =>
                x.OwnerName.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.LineOne.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.LineTwo.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.PostCode.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.City.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.Country.ToLower().Contains(tb.Text.ToLower()) ||
                x.Phone.ToLower().Contains(tb.Text.ToLower())
                );
                DataGridElement.ItemsSource = null;
                DataGridElement.ItemsSource = filterProperty;
            }
            else
            {
                DataGridElement.ItemsSource = new PropertyModelView<PropertyData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        public void Dsort()
        {
            var DESCsortGrid = Propdata.GetAll().OrderByDescending(x => x.OwnerName.ToLower());
            DataGridElement.ItemsSource = null;
            DataGridElement.ItemsSource = DESCsortGrid;
        }

        public void Asort()
        {
            var ASCsort = Propdata.GetAll().OrderBy(x => x.OwnerName.ToLower());
            DataGridElement.ItemsSource = null;
            DataGridElement.ItemsSource = ASCsort;
        }
    }
}

