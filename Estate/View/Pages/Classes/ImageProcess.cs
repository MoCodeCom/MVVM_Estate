using Estate.ModelView.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Image = System.Drawing.Image;

namespace Estate.View.Pages.Classes
{
    public static class ImageProcess
    {

        public static byte[] UploadByte()
        {
            byte[] b = new byte[] { 0 };
            OpenFileDialog fd = new OpenFileDialog()
            {
                Filter = "Image files(*.jpg)|*.jpg",
                Multiselect = false
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string pathImage = fd.FileName;
                Image i = Image.FromFile(pathImage);
                byte[] byteImage = ImageToByteArray(i);

                return byteImage;
            }
            else
            {
                MessageBox.Show("The property image will delete?");
                return b;
            }

        }

        private static byte[] ImageToByteArray(Image i)
        {
            Image image = (System.Drawing.Image)i;
            using (MemoryStream img = new MemoryStream())
            {
                i.Save(img, image.RawFormat);
                return img.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] data)
        {
            DefaultImage di = new DefaultImage();
            if (data.Length < 2)
            {
                data = di.GetDefaultImageBytes("property_Default_Image");
            }
            using (MemoryStream b = new MemoryStream(data))
            {
                return Image.FromStream(b);
            }
        }

        //public static System.Windows.Media.Imaging.BitmapImage byteToBitmap(byte data)
        //{
        //    using (MemoryStream b = new MemoryStream(data))
        //    {
        //        BitmapImage bmi = new BitmapImage();
        //        bmi.BeginInit();
        //        bmi.CacheOption = BitmapCacheOption.OnLoad;
        //        bmi.StreamSource = b;
        //        bmi.EndInit();
        //        return bmi;
        //    }
        //}

        //public static Image UriToDrawingImage(string uri)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        BmpBitmapEncoder bmp = new BmpBitmapEncoder();
        //        bmp.Frames.Add(BitmapFrame.Create(new Uri(uri)));
        //        bmp.Save(ms);
        //        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

        //        if (image.GetType().ToString() == "System.Drawing.Bitmap")
        //        {
        //            MessageBox.Show("ttt");
        //            MemoryStream msconvert = new MemoryStream();
        //            image.Save(msconvert, ImageFormat.Jpeg);
        //            ResXResourceWriter writer = new ResXResourceWriter(msconvert);

        //        }




        //        //MessageBox.Show(image.GetType().ToString());
        //        return image;
        //    }
        //}

        //public static byte[] DefaultImage(string uriStr)
        //{
        //    string defaultImageUri = uriStr;
        //    Image defaultImage = UriToDrawingImage(defaultImageUri);
        //    byte[] byteNullImage = ImageToByteArray(defaultImage);
        //    return byteNullImage;
        //}

    }
}
