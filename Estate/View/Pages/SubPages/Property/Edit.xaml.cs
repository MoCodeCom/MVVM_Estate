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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        PropertyModelView<PropertyData> Propdata = new PropertyModelView<PropertyData>();
        public Edit()
        {
            InitializeComponent();
            DataGridPorpertyEdit.ItemsSource = Propdata.GetAllData;
        }

        private void DataGridPorpertyEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ItemProp = DataGridPorpertyEdit.SelectedItem as PropertyData;
            if (ItemProp != null)
            {
                string NameStr = ItemProp.FullName.ToLower();
                var i = Propdata.GetAll().Where(x => x.FullName.ToLower() == NameStr);
                foreach (var items in i)
                {
                    txtFullName.Text = items.FullName;
                    txtLineOne.Text = items.LineOne;
                    txtLineTwo.Text = items.LineTwo;
                    txtCountry.Text = items.Country;
                    txtCity.Text = items.City;
                    txtPostCode.Text = items.PostCode;
                    txtPhone.Text = items.Phone;

                    break;
                }
            }
        }


 

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = Propdata.GetAllData.Where(x =>
                x.FullName.ToLower().Contains(tb.Text.ToLower()) ||
                x.PostCode.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridPorpertyEdit.ItemsSource = null;
                DataGridPorpertyEdit.ItemsSource = filterTenant;
            }
            else
            {
                DataGridPorpertyEdit.ItemsSource = new PropertyModelView<PropertyData>().GetAllData;
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }


    }
}
