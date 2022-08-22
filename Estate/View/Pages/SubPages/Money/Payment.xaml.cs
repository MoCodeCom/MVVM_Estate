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

namespace Estate.View.Pages.SubPages.Money
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Page
    {
        PaymentModelView<PaymentData> pvdate = new PaymentModelView<PaymentData>();
        public Payment()
        {
            InitializeComponent();
            DataGridMoneyPayment.ItemsSource = pvdate.GetAllData;
        }

        private void DataGridMoneyPayment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

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
                var filterMoney = pvdate.GetAllData.Where(x =>
                x.tansaction.ToLower().Contains(tb.Text.ToLower()) ||
                x.date.ToLower().Contains(tb.Text.ToLower()) ||
                x.amount.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridMoneyPayment.ItemsSource = null;
                DataGridMoneyPayment.ItemsSource = filterMoney;
            }
            else
            {
                DataGridMoneyPayment.ItemsSource = new PaymentModelView<PaymentData>().GetAllData;
            }
        }
    }
}
