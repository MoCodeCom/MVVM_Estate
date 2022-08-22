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

namespace Estate.View.Pages.SubPages.Landlord
{
    /// <summary>
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
        LandlordModelView<LandlordData> lldata = new LandlordModelView<LandlordData>();
        public Delete()
        {
            InitializeComponent();
            DataGridLandlord.ItemsSource = new LandlordModelView<LandlordData>().GetAllData;
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterLandlord = lldata.GetAllData.Where(x =>
                x.FirstName.ToLower().Contains(tb.Text.ToLower()) ||
                x.LastName.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.PostCode.ToLower().Contains(tb.Text.ToLower()) ||
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure to delete all landlords details in the system?");
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = DataGridLandlord.SelectedItem as LandlordData;   
                MessageBox.Show(selectedItem.FirstName.ToString() + " will deleted");
                string fullname = (selectedItem.FirstName+selectedItem.LastName).ToString();
                

                DataGridLandlord.ItemsSource = lldata.DeleteByFullName(fullname);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
