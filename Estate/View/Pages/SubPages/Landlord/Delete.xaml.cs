﻿using Estate.Model.Data;
using Estate.ModelView;
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

namespace Estate.View.Pages.SubPages.Landlord
{
    /// <summary>
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
        private static LandlordData landlordData;
        LandlordModelView<LandlordData> lldata = new LandlordModelView<LandlordData>();
       
        
        public Delete()
        {
            InitializeComponent();
            DataGridLandlord.ItemsSource = new LandlordModelView<LandlordData>().GetAll();
        }

        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterLandlord = lldata.GetAll().Where(x =>
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
                DataGridLandlord.ItemsSource = new LandlordModelView<LandlordData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Are you sure to delete all landlords details from the system?","Delete All",
                MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            try
            {
                switch (Result)
                {
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.OK:
                        //To delete all details form database.
                        lldata.DeleteAll();

                        MessageBox.Show("Delete is done.");
                        DataGridLandlord.ItemsSource = new LandlordModelView<LandlordData>().GetAll();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        break;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = DataGridLandlord.SelectedItem as LandlordData;   
                MessageBoxResult Result =  MessageBox.Show(selectedItem.FirstName.ToString()+ " will delete from the system.","Delete",
                    MessageBoxButton.OKCancel,MessageBoxImage.Warning);
                switch (Result)
                {
                    case MessageBoxResult.None:

                        break;
                    case MessageBoxResult.OK:
                        //To get the item's id.
                        //int SeletctedItemId = Convert.ToInt32( lldata.GetId(selectedItem));
                        int SeletctedItemId = Convert.ToInt32(lldata.GetId(selectedItem));
                        //To delete item by id.
                        lldata.DeleteById(SeletctedItemId);

                        MessageBox.Show("Delete is done.");
                        DataGridLandlord.ItemsSource = new LandlordModelView<LandlordData>().GetAll();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
