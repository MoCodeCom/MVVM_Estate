using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Estate.View.Pages.Classes
{
    internal class colorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            int num;
            Brush color=null;
            
            string valueStr = value as string;  
            if (Int32.TryParse(valueStr, out num))
            {
                color = (num >= 0) ? Brushes.Green : Brushes.Red;
            }

            return color;
            

            //// Or we can use this code to change the color according to the value amount.
            /*
            int val = 0;
            //value = "0";
            val = Int32.Parse((value as string));
            
            Brush brsh = null;
            if (val > 0) 
            {
                brsh = Brushes.Green;
            }
            else
            {
                brsh = Brushes.Red;
            }
            

            return brsh;
            */

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
