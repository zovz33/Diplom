using System;
using System.Globalization;
using System.Windows.Data;

namespace PrimeTableware.WPF.Converters
{
    public class BooleanToCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked)
                return '\0';
            else
                return '•'; // или любой другой символ для замены пароля
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
