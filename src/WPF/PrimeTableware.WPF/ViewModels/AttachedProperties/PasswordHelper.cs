using System.Windows.Controls;
using System.Windows;

namespace PrimeTableware.WPF.ViewModels
{
    public static class PasswordHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordHelper),
                new FrameworkPropertyMetadata(string.Empty, OnBoundPasswordChanged));

        private static readonly DependencyProperty UpdatingPasswordProperty =
            DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false));

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var PasswordBox = d as PasswordBox;

            if (PasswordBox == null)
            {
                return;
            }

            PasswordBox.PasswordChanged -= PasswordChanged;

            if (!((bool)GetUpdatingPassword(PasswordBox)))
            {
                PasswordBox.Password = (string)e.NewValue;
            }

            PasswordBox.PasswordChanged += PasswordChanged;
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var PasswordBox = sender as PasswordBox;

            SetUpdatingPassword(PasswordBox, true);
            SetBoundPassword(PasswordBox, PasswordBox.Password);
            SetUpdatingPassword(PasswordBox, false);
        }

        public static void SetBoundPassword(PasswordBox element, string value)
        {
            element.SetValue(BoundPasswordProperty, value);
        }

        public static string GetBoundPassword(PasswordBox element)
        {
            return (string)element.GetValue(BoundPasswordProperty);
        }

        private static bool GetUpdatingPassword(DependencyObject obj)
        {
            return (bool)obj.GetValue(UpdatingPasswordProperty);
        }

        private static void SetUpdatingPassword(DependencyObject obj, bool value)
        {
            obj.SetValue(UpdatingPasswordProperty, value);
        }
    }
}