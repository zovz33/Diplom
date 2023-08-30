using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Data;

namespace PrimeTableware.WPF.Converters
{
    public class SecureStringToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            SecureString secureString = value as SecureString;
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            SecureString secureString = new SecureString();
            foreach (char c in value.ToString())
                secureString.AppendChar(c);

            secureString.MakeReadOnly();
            return secureString;
        }
    }
}
