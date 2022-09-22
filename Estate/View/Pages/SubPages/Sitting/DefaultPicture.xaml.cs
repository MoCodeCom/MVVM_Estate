using Estate.ModelView.Classes;
using Estate.View.Pages.Classes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace Estate.View.Pages.SubPages.Sitting
{
    /// <summary>
    /// Interaction logic for DefaultPicture.xaml
    /// </summary>
    public partial class DefaultPicture : Page
    {
        DefaultImage di = new DefaultImage();
        public List<byte[]> ImagesByte = new List<byte[]>()
        {
            new byte[]{ 0}
        };
        public DefaultPicture()
        {
            InitializeComponent();
            DefaultPropertyImage.IsEnabled = di.GetImageByName("property_Default_Image") ? false:true;
        }

        private void DefaultPropertyImage_Click(object sender, RoutedEventArgs e)
        {
            bool check = di.GetImageByName("property_Default_Image");
            if (check == true)
            {
                MessageBox.Show("The image is exist already!");
            }
            else
            {
                byte[] imageAsByte = ImageProcess.UploadByte();
                ImagesByte[0] = imageAsByte;
                MessageBox.Show("Upload is done! " + ImagesByte.Count);
            }
            
        }

        private void SaveSetting_Click(object sender, RoutedEventArgs e)
        {
            bool checkPropertyImage = di.GetImageByName("property_Default_Image");
            if (checkPropertyImage == true)
            {
                MessageBox.Show("Image property is added.");
            }
            else
            {
                di.AddDefaultImage(ImagesByte[0]);
                MessageBox.Show("Image property is added.");
            }
        }
    }
}
