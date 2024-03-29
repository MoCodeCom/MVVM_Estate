﻿using Estate.Model.Data;
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

namespace Estate.View.Pages.SubPages.Property
{
    /// <summary>
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {

        PropertyModelView<PropertyData> Propdata = new PropertyModelView<PropertyData>();
        public Delete()
        {
            InitializeComponent();
            DataGridProperty.ItemsSource = new PropertyModelView<PropertyData>().GetAll();
        }


        private void Filter(TextBox tb)
        {
            if (tb.Text != "")
            {
                var filterProperty = Propdata.GetAll().Where(x =>
                x.OwnerName.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.LineOne.ToLower().Contains(tb.Text.ToLower())||
                x.Address.LineTwo.ToLower().Contains(tb.Text.ToLower()) ||
                x.Address.City.ToLower().Contains(tb.Text.ToLower())||
                x.Address.Country.ToLower().Contains(tb.Text.ToLower())||
                x.Address.PostCode.ToLower().Contains(tb.Text.ToLower()) ||
                x.Phone.ToLower().Contains(tb.Text.ToLower())

                );
                DataGridProperty.ItemsSource = null;
                DataGridProperty.ItemsSource = filterProperty;
            }
            else
            {
                DataGridProperty.ItemsSource = new PropertyModelView<PropertyData>().GetAll();
            }
        }
        private void FilterContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtbox = sender as TextBox;
            Filter(txtbox);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure to delete all landlords details in the system?");
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = DataGridProperty.SelectedItem as PropertyData;
                MessageBoxResult Result = MessageBox.Show(selectedItem.Address.PostCode.ToString() + " will delete from the system.", "Delete",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                switch (Result)
                {
                    case MessageBoxResult.None:

                        break;
                    case MessageBoxResult.OK:
                        //To get the item's id.
                        //int SeletctedItemId = Convert.ToInt32( lldata.GetId(selectedItem));
                        int SeletctedItemId = Convert.ToInt32(Propdata.GetIdByPostcode(selectedItem.Address.PostCode));
                        //To delete item by id.
                        Propdata.DeleteById(SeletctedItemId);

                        MessageBox.Show("Delete is done.");
                        DataGridProperty.ItemsSource = new PropertyModelView<PropertyData>().GetAll();
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
