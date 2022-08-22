using Estate.View.Pages.Classes;
using Estate.View.Pages.SubPages.Money;
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

namespace Estate.Pages
{
    /// <summary>
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        public PaymentPage()
        {
            InitializeComponent();
            initial();
        }

        public void initial()
        {
            Money MoneyPage = new Money();
            FrameChange f = new FrameChange(MoneyPage, MoneyFrame);
        }

        private void btnAscending_Click(object sender, RoutedEventArgs e)
        {

            Money m = new Money();
            FrameChange f = new FrameChange(m, MoneyFrame);
            m.Asort();
        }

        private void btnDescending_Click(object sender, RoutedEventArgs e)
        {

            Money m = new Money();
            FrameChange f = new FrameChange(m, MoneyFrame);
            m.Dsort();
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Money m = new Money();
            FrameChange f = new FrameChange(m, MoneyFrame);
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            Payment p = new Payment();
            FrameChange f = new FrameChange(p , MoneyFrame);

        }

        private void btnRecivable_Click(object sender, RoutedEventArgs e)
        {
            Recivable r = new Recivable();
            FrameChange f = new FrameChange(r, MoneyFrame);
        }

        private void btnMoneyEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit();
            FrameChange f = new FrameChange(edit, MoneyFrame);
        }

        private void btnMoneyDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete d = new Delete();
            FrameChange f = new FrameChange(d, MoneyFrame);
        }
    }
}
