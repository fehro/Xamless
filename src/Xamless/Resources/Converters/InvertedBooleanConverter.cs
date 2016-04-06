using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Xamless.Resources.Converters
{
    public class InvertedBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var booleanValue = value as bool?;
            if (booleanValue.HasValue)
            {
                return !booleanValue.Value;
            }

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var booleanValue = value as bool?;
            if (booleanValue.HasValue)
            {
                return !booleanValue.Value;
            }

            return false;
        }
    }
}
