using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Estate.View.Pages.Classes
{
    public class AlignmentConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num;
            string AlignmentChange = "";
            string valueStrs = value as string;
            if (Int32.TryParse(valueStrs, out num))
            {
                AlignmentChange = num >= 0 ? "Right" : "Center";
            }

            return AlignmentChange;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
