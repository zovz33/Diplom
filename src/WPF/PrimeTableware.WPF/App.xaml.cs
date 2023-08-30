using PrimeTableware.WPF.Views;
using System;
using System.Windows;

namespace PrimeTableware.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            var MainW = new Views.MainWindow();
            MainW.Show();
            MainW.IsVisibleChanged += (s, ev) =>
            {
                if (MainW.IsVisible == false && MainW.IsLoaded)
                {
                    if (Application.Current.MainWindow != null)
                        ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Uri("Views/UserPage.xaml",
                            UriKind.RelativeOrAbsolute));
                }
            };
            base.OnStartup(e);
        }
    }
}
