using System;
using System.Globalization;
using System.Net;
using System.Security;
using System.Windows.Data;

namespace PrimeTableware.WPF.Converters
{
    public class PasswordLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string password = new NetworkCredential(string.Empty, (SecureString)value).Password;
            return password.Length;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
