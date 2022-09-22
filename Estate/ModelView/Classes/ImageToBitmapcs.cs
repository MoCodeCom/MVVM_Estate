using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows.Controls;
using Image = System.Drawing.Image;
using System.IO;
using System.Net;

namespace Estate.ModelView.Classes
{
    public static class ImageToBitmapcs
    {
        public static BitmapSource GetBitmapByImage(Image i)
        {
            //var nullImage = new BitmapImage(new Uri("pack://application:,,,/Model/Images/Landlord.png"));
            Bitmap bitmap = new Bitmap(i);

            IntPtr intptr = bitmap.GetHbitmap();
            BitmapSource bitmapsource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                intptr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()
                );
            bitmapsource.Freeze();
            return bitmapsource;
        }
    }
}
