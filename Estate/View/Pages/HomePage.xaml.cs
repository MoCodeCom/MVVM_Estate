using Estate.ModelView.Classes;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    /// 
    
    public partial class HomePage : Page
    {
        CheckConnectionDatabase checkConnection = new CheckConnectionDatabase();
        public HomePage()
        {
            InitializeComponent();
            connectionBtnVisibility();
        }


        public void connectionBtnVisibility()
        {
            if (checkConnection.checkConnection() == false)
            {
                connectionBtn.Visibility = Visibility.Visible;
                connectionDatabaseState.Visibility = Visibility.Visible;
                connectionDatabaseState.Content = "There is not database connectoin!";
                
            }
            else 
            { 
                connectionBtn.Visibility = Visibility.Hidden;
                connectionDatabaseState.Visibility = Visibility.Hidden;
            }
        }

        
    }
}
