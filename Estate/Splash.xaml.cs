using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
using System.Windows.Threading;

namespace Estate
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        DispatcherTimer dp = new DispatcherTimer();
        public Splash()
        {
            InitializeComponent();
            dp.Tick += new EventHandler(dt);
            dp.Interval = new TimeSpan(0, 0, 0);
            dp.Start();
        }

        private void dt(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();

            dp.Stop();
            this.Close();
        }
    }
}
