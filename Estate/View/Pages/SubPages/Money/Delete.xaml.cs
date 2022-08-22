using Estate.Model.Data;
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

namespace Estate.View.Pages.SubPages.Money
{
    /// <summary>
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
        List<MoneyListData> liMoney = new Money().bothList();
        public Delete()
        {
            InitializeComponent();
            DataGridMoneyDelete.ItemsSource = null;
            DataGridMoneyDelete.ItemsSource = liMoney;
        }

        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            Filter(tb);
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterMoney = liMoney.Where(x =>
                x.tansaction.ToLower().Contains(tb.Text.ToLower()) ||
                x.date.ToLower().Contains(tb.Text.ToLower()) ||
                x.amount.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridMoneyDelete.ItemsSource = null;
                DataGridMoneyDelete.ItemsSource = filterMoney;
            }
            else
            {
                DataGridMoneyDelete.ItemsSource = liMoney;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridMoneyDelete_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
