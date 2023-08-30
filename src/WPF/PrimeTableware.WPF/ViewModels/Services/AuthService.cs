using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories;
using PrimeTableware.WPF.Repositories.Interfaces;
using PrimeTableware.WPF.Views;
using System;
using System.Security.Principal;
using System.Threading;
using System.Windows;

namespace PrimeTableware.WPF.ViewModels.Services
{
    public class AuthService : IAuthService // AuthService отвечает за аутентификацию пользователей 
    {
        private readonly IUserRepository userRepository;
        public bool IsLoggedIn { get; private set; }
        public string ErrorMessage { get; private set; }
        public AuthService()
        {
            userRepository = new UserRepository();
        }

        public void Logout()
        {
            IsLoggedIn = false;

            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity(""), null);
            if (Application.Current.MainWindow != null)
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Uri("Views/AuthPage.xaml",
                    UriKind.RelativeOrAbsolute));
        }

    }
}