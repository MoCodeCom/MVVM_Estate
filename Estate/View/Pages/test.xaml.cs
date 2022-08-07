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
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Page
    {
        public test()
        {
            
            
            InitializeComponent();
            CalenderDiry.MouseDoubleClick += testPrint;
            
        }

        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var calender = sender as Calendar;
            if (calender.SelectedDate.HasValue)
            {
                DateTime dt = calender.SelectedDate.Value;
                MessageBox.Show(dt.Day.ToString()); ;
            }
        }

        public void testPrint(object sender,EventArgs e)
        {
            DateTime dt = CalenderDiry.SelectedDate.Value;
            var v = CalenderDiry.SelectedDate;
            MessageBox.Show(dt.Day.ToString());
        }
    }
}
