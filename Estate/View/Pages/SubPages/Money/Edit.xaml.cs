using Estate.Model.Data;
using Estate.Model.Interface;
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

namespace Estate.View.Pages.SubPages.Money
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        List<MoneyListData> liMoney = new Money().bothList();
        public Edit()
        {
            InitializeComponent();
            DataGridMoneyEdit.ItemsSource = null;
            DataGridMoneyEdit.ItemsSource = liMoney;
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
                DataGridMoneyEdit.ItemsSource = null;
                DataGridMoneyEdit.ItemsSource = filterMoney;
            }
            else
            {
                DataGridMoneyEdit.ItemsSource = liMoney;
            }
        }


        private void DataGridMoneyEdit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ItemMoney = DataGridMoneyEdit.SelectedItem as MoneyListData;
            if (liMoney != null)
            {
                string TransactionStr = ItemMoney.tansaction.ToLower();
                var i = liMoney.Where(x => x.tansaction.ToLower() == TransactionStr);
                foreach (var items in i)
                {
                    txtTransaction.Text = items.tansaction;
                    txtDate.Text = items.date;
                    txtAmount.Text = items.amount;
                    txtState.Text = items.state;
                    txtIssued.Text = items.issued;
                    txtPaymentMethod.Text = items.paymentMethod;


                    break;
                }
            }
        }

    }

   
}
