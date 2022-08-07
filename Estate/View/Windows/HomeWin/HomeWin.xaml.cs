using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Estate.Pages;

namespace Estate.Windows.HomeWin
{
    /// <summary>
    /// Interaction logic for HomeWin.xaml
    /// </summary>
    public partial class HomeWin : Window
    {
        AppDate ad;
        public HomeWin()
        {
            InitializeComponent();

            FrameHomeMain.Content = new HomePage().Content;
            dateHomeWin(); // to implement Date Calender in Home Window
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            App.Current.Shutdown();
        }
        /// <summary>
        /// (dateHomeWin) 
        /// Method to connection items in the home window and AppDate class.
        /// </summary>
        public void dateHomeWin()
        {
            ad = new AppDate();
            DayDateHomeWin.Text = ad.AppDateHomeWin()[0];
            MonthDateHomeWin.Text = ad.AppDateHomeWin()[1];
            
        }

        private void Landlord_Button_Click(object sender, RoutedEventArgs e)
        {
            LandlordPage lp = new LandlordPage();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = lp.Content;
        }

        private void Tenant_Button_Click(object sender, RoutedEventArgs e)
        {
            TenantPage tp = new TenantPage();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = tp.Content;
        }

        private void Property_Button_Click(object sender, RoutedEventArgs e)
        {
            PropertyPage pp = new PropertyPage();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = pp.Content;
        }

        private void Money_Button_Click(object sender, RoutedEventArgs e)
        {
            PaymentPage pp = new PaymentPage();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = pp.Content;
        }

        private void Contract_Button_Click(object sender, RoutedEventArgs e)
        {
            ContractPage cp = new ContractPage();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = cp.Content;
        }

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            ReportPage rp = new ReportPage();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = rp.Content;
        }

        private void Setting_Button_Click(object sender, RoutedEventArgs e)
        {
            SettingPage sp = new SettingPage();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = sp.Content;
        }

        private void Diry_Button_Click(object sender, RoutedEventArgs e)
        {
            int days = DateTime.DaysInMonth(2022, 7);
            //MessageBox.Show(days.ToString());
            DiryPage dp = new DiryPage();
            test t = new test();
            if (FrameHomeMain.Content != null)
            {
                FrameHomeMain.Content = null;
            }
            FrameHomeMain.Content = dp.Content;
        }
    }

    /// <AppDate>
    /// class to set the Date in the calender in home window
    /// </>
    public class AppDate
    {
        public string[] AppDateHomeWin()
        {
            
            string dayDt = DateTime.Now.ToString("dd");
            string monthDt = DateTime.Now.ToString("MMMM");
            string[] dateArr = {dayDt, monthDt };

            return dateArr;
        }
    }
    
}
