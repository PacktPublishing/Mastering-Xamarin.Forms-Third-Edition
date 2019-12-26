using System;
using System.Globalization;
using Xamarin.Forms;

namespace TripLog.Converters
{
    public class ReverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Boolean))
            {
                return value;
            }

            return !(Boolean)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Boolean))
            {
                return value;
            }

            return !(Boolean)value;
        }
    }
}
