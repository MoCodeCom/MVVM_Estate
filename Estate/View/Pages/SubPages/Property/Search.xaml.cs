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
            DataGridElement.ItemsSource = new PropertyModelView<PropertyData>().GetAllData;
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterProperty = Propdata.GetAllData.Where(x =>
                x.FullName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LineOne.ToLower().Contains(tb.Text.ToLower()) ||
                x.LineTwo.ToLower().Contains(tb.Text.ToLower()) ||
                x.PostCode.ToLower().Contains(tb.Text.ToLower()) ||
                x.City.ToLower().Contains(tb.Text.ToLower()) ||
                x.Country.ToLower().Contains(tb.Text.ToLower()) ||
                x.Phone.ToLower().Contains(tb.Text.ToLower())
                );
                DataGridElement.ItemsSource = null;
                DataGridElement.ItemsSource = filterProperty;
            }
            else
            {
                DataGridElement.ItemsSource = new PropertyModelView<PropertyData>().GetAllData;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        public void Dsort()
        {
            var DESCsortGrid = Propdata.GetAllData.OrderByDescending(x => x.FullName.ToLower());
            DataGridElement.ItemsSource = null;
            DataGridElement.ItemsSource = DESCsortGrid;
        }

        public void Asort()
        {
            var ASCsort = Propdata.GetAllData.OrderBy(x => x.FullName.ToLower());
            DataGridElement.ItemsSource = null;
            DataGridElement.ItemsSource = ASCsort;
        }
    }
}

