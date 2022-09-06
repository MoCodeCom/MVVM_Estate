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
            DataGridPorpertyEdit.ItemsSource = Propdata.GetAll();
        }

        private void DataGridPorpertyEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ItemProp = DataGridPorpertyEdit.SelectedItem as PropertyData;
            if (ItemProp != null)
            {
                string NameStr = ItemProp.OwnerName.ToLower();
                var i = Propdata.GetAll().Where(x => x.OwnerName.ToLower() == NameStr);
                foreach (var items in i)
                {
                    txtFullName.Text = items.OwnerName;
                    txtLineOne.Text = items.Address.LineOne;
                    txtLineTwo.Text = items.Address.LineTwo;
                    txtCountry.Text = items.Address.Country;
                    txtCity.Text = items.Address.City;
                    txtPostCode.Text = items.Address.PostCode;
                    txtPhone.Text = items.Phone;

                    break;
                }
            }
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterTenant = Propdata.GetAll().Where(x =>
                x.OwnerName.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.PostCode.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridPorpertyEdit.ItemsSource = null;
                DataGridPorpertyEdit.ItemsSource = filterTenant;
            }
            else
            {
                DataGridPorpertyEdit.ItemsSource = new PropertyModelView<PropertyData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtbox = sender as TextBox;
            Filter(txtbox);
        }


    }
}
