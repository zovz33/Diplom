using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories;
using PrimeTableware.WPF.ViewModels.Commands;
using PrimeTableware.WPF.Views;
using System;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.Data.SqlClient;
using PrimeTableware.WPF.ViewModels.Services;
using PrimeTableware.WPF.Repositories.Interfaces;
using System.Collections.Generic;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Windows.Controls;

namespace PrimeTableware.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Объявление переменных
        public bool IsLoginValid { get; set; }
        public bool IsPasswordValid { get; set; }
        public bool IsLoggedIn { get; set; }
        
        private readonly IUserRepository userRepository;
        private readonly IAuthService authService;

        private string _username = null;
        public string Username
        {
            get { return _username; }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                Validate();
            }
        }

        private SecureString _password = null;
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                Validate();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private RoleModel _role;
        public RoleModel Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private Visibility _controlVisibility = Visibility.Collapsed;
        public Visibility ControlVisibility
        {
            get { return _controlVisibility; }
            set
            {
                _controlVisibility = value;
                OnPropertyChanged(nameof(ControlVisibility));
            }
        }

        #endregion

        #region Объявление команд

        public ICommand LoginCommand { get; }
        public ICommand VKAuthNavigationCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        #endregion
 
        public LoginViewModel()
        {
            authService = new AuthService();
            userRepository = new UserRepository(); 
            LoginCommand = new ViewModelCommand(LoginInCommand, CanLoginInCommand);
            VKAuthNavigationCommand = new RelayCommand (VKAuthNavigation);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private void VKAuthNavigation(object obj) // Открытие окна авторизации VKontakte
        {
            if (ControlVisibility == Visibility.Collapsed)
            {
                ControlVisibility = Visibility.Visible;
            }
            else
            {
                ControlVisibility = Visibility.Collapsed;
            }
        }

        #region Проверка логина и пароля :) и авторизация

        private void Validate()
        {
            if (string.IsNullOrEmpty(Username) || Username.Length < 3)
            {
                IsLoginValid = false;
            }
            else
            {
                IsLoginValid = true;
            }

            if (Password == null || Password.Length < 3)
            {
                IsPasswordValid = false;
            }
            else
            {
                IsPasswordValid = true;
            }

            if (IsLoginValid && IsPasswordValid)
            {
                ErrorMessage = "";
            }
        }

        private bool CanLoginInCommand(object obj) // Проверка может ли выполниться метод выполнения команды входа(если нет, то нажать кнопку не представляется возможным :3
        {

            if (!IsLoginValid && !IsPasswordValid)
            {
                ErrorMessage = "Введите логин и пароль(более 3-ёх символов)";
                return false;
            }
            else if (!IsLoginValid)
            {
                ErrorMessage = "Введите логин(более 3-ёх символов)";
                return false;
            }
            else if (!IsPasswordValid)
            {
                ErrorMessage = "Введите пароль(более 3-ёх символов)";
                return false;
            }

            return true;
        }

        private void LoginInCommand(object obj) // метод проверки существования логина и пароля
        {
            var user = userRepository.GetByUsername(Username);
            if (user == null) // если пользователь не найден по логину
            {
                ErrorMessage = "Пользователь с таким логином не найден.";
                return;
            }

            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser) // если логи и пароль совпадают, то выполняем
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsLoggedIn = true;

           

                if (Application.Current.MainWindow != null)
                    ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Uri("Views/UserPage.xaml",
                        UriKind.RelativeOrAbsolute));
            }
            else
            {
                ErrorMessage = "Пароль введен неверно";
            }
        }

        #endregion
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
