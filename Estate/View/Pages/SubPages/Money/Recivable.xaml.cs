using Estate.Model.Data;
using Estate.ModelView;
using Estate.Windows.HomeWin;
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
    /// Interaction logic for Recivable.xaml
    /// </summary>
    public partial class Recivable : Page
    {
        RecivableModelView<RecivableData> rdvData = new RecivableModelView<RecivableData>();

        public Recivable()
        {
            InitializeComponent();
            DataGridMoneyRecivable.ItemsSource = rdvData.GetAllData;
        }

        private void DataGridMoneyRecivable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                var filterMoney = rdvData.GetAllData.Where(x =>
                x.tansaction.ToLower().Contains(tb.Text.ToLower()) ||
                x.date.ToLower().Contains(tb.Text.ToLower()) ||
                x.amount.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridMoneyRecivable.ItemsSource = null;
                DataGridMoneyRecivable.ItemsSource = filterMoney;
            }
            else
            {
                DataGridMoneyRecivable.ItemsSource = new RecivableModelView<RecivableData>().GetAllData;
            }
        }
    }
}
