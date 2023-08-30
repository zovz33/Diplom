using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PrimeTableware.WPF.ViewModels.Services;
using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories;
using PrimeTableware.WPF.ViewModels.Commands;
using PrimeTableware.WPF.Views.NavigationPages;
using Comments = PrimeTableware.WPF.Views.NavigationPages.Comments;
using PrimeTableware.WPF.Repositories.Interfaces;
using PrimeTableware.WPF.Views.BottomNavigationPages;

namespace PrimeTableware.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        private IAuthService authService;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        #region Объявление элементов в View
        private object _currentPage;
        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        #endregion

        #region Объявление команд
        public ICommand LogoutCommand { get; }
        public ICommand MainCommand { get; }
        public ICommand PersonalCommand { get; }
        public ICommand KatalogCommand { get; }
        public ICommand KorzinaCommand { get; }
        public ICommand FavoritesCommand { get; }
        public ICommand ChartsPansCommand { get; }
        public ICommand DataCommand { get; }
        public ICommand ReviewCommand { get; }
        public ICommand SettingsCommand { get; }

        #endregion

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            authService = new AuthService();    
            LoadCurrentUserData();
            LogoutCommand = new RelayCommand(Logout);
            #region NavigationCommand
            MainCommand = new RelayCommand(MainPageNavigation);
            PersonalCommand = new RelayCommand(PersonalAccountNavigation);
            KatalogCommand = new RelayCommand(KatalogNavigation);
            KorzinaCommand = new RelayCommand(KorzinaNavigation);
            FavoritesCommand = new RelayCommand(FavoritesNavigation);
            ChartsPansCommand = new RelayCommand(ChartsPlansNavigation);
            DataCommand = new RelayCommand(DataNavigation);
            ReviewCommand = new RelayCommand (ReviewNavigation);
            SettingsCommand = new RelayCommand(SettingsNavigation);
            #endregion
        }
        private void Logout(object obj)
        {
            authService.Logout();
        }
        #region Navigation
        private void MainPageNavigation(object obj)
        {
            CurrentPage = new MainPage();
        }
        private void PersonalAccountNavigation(object obj)
        {
            CurrentPage = new PersonalAccount();
        }
        private void KatalogNavigation(object obj)
        {
            CurrentPage = new Katalog();
        }
        private void KorzinaNavigation(object obj)
        {
            CurrentPage = new Korzina();
        }
        private void FavoritesNavigation(object obj)
        {
            CurrentPage = new Favorites();
        }
        private void ChartsPlansNavigation(object obj)
        {
            CurrentPage = new ChartsPlans();
        }
        private void DataNavigation(object obj)
        {
            CurrentPage = new Data();
        }
        private void ReviewNavigation(object obj)
        {
            CurrentPage = new Comments();
        }
        private void SettingsNavigation(object obj)
        {
            CurrentPage = new SettingsPage();
        }

        #endregion
        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null) // Пользователь - авторизирован
            {
                CurrentUserAccount.UserIDModel = user.idUser;
                CurrentUserAccount.LoginModel = user.Login;
                CurrentUserAccount.UsernameSurnameModel = user.Name + " " + user.Surname;
                if (user.idRole == 1)
                {
                    CurrentUserAccount.UserRoleModel = "Администратор";
                }
                else if (user.idRole == 2)
                {
                    CurrentUserAccount.UserRoleModel = "Сотрудник";
                }
                else if (user.idRole == 3)
                {
                    CurrentUserAccount.UserRoleModel = "Пользователь";
                }
                CurrentUserAccount.NameModel = user.Name;
                CurrentUserAccount.SurnameModel = user.Surname;
                CurrentUserAccount.MailModel = user.Mail;
                CurrentUserAccount.MobilePhoneModel = user.MobilePhone;
                CurrentUserAccount.FNameModel = user.FName;
                CurrentUserAccount.GenderModel= user.Gender;
                CurrentUserAccount.AdressModel = user.Adress;
                CurrentUserAccount.HomePhoneModel = user.HomePhone;
                CurrentUserAccount.DateOfBornModel = user.DateOfBorn;
                CurrentUserAccount.DateAddModel = user.DateAdd;
                CurrentUserAccount.DateEditModel = user.DateEdit;
                if (string.IsNullOrEmpty(user.ProfileImage)) // если в базе данных null
                {
                    CurrentUserAccount.ImageModel = "C:\\Users\\User\\source\\repos\\CourseManufacture\\PrimeTableware.WPF\\Recources\\неизвестный.jpg";
                }
                else // если не null кароче выводим профиле имаже да
                CurrentUserAccount.ImageModel = user.ProfileImage;
            }
            else // Если не авторизирован
            {
                CurrentUserAccount.LoginModel = "Вы не авторизированы";
                CurrentUserAccount.UsernameSurnameModel = "Имя Фамилия";
                CurrentUserAccount.ImageModel = "C:\\Users\\User\\source\\repos\\CourseManufacture\\PrimeTableware.WPF\\Recources\\неизвестный.jpg";
                CurrentUserAccount.UserRoleModel = "Роль";
                CurrentUserAccount.DateAddModel = DateTime.Now;
            }
        }
 
    }
}
