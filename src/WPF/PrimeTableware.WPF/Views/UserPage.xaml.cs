using PrimeTableware.WPF.ViewModels;
using PrimeTableware.WPF.Views.NavigationPages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PrimeTableware.WPF.Views
{
    public partial class UserPage : Page
    {
        private readonly Duration _openCloseDuration = new Duration(TimeSpan.FromSeconds(0.25));
        public UserPage()
        {
            InitializeComponent();
            GridNavigationBar.Width = 0;
        }
        private void OpenDropMenu()
        {
            GridNavigationBar.Measure(new Size(GridNavigationBar.MaxWidth, GridNavigationBar.MaxHeight));
            DoubleAnimation widthAnimation = new DoubleAnimation(0, 200, _openCloseDuration);
            GridNavigationBar.BeginAnimation(WidthProperty, widthAnimation);
            ButtonCloseDrop.Visibility = Visibility.Visible;
            ButtonOpenDrop.Visibility = Visibility.Hidden;
        }
        private void CloseDropMenu()
        {
            DoubleAnimation widthAnimation = new DoubleAnimation(0, _openCloseDuration);
            GridNavigationBar.BeginAnimation(WidthProperty, widthAnimation);
            ButtonCloseDrop.Visibility = Visibility.Hidden;
            ButtonOpenDrop.Visibility = Visibility.Visible;
        }
        private void ButtonOpenDropMenu(object sender, RoutedEventArgs e)
        {
            OpenDropMenu();
        }
        private void ButtonCloseDropMenu(object sender, RoutedEventArgs e)
        {
            CloseDropMenu();
        }
 
 
    }
}
