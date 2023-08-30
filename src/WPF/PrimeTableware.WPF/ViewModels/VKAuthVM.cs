using PrimeTableware.WPF.ViewModels.Commands;
using PrimeTableware.WPF.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeTableware.WPF.ViewModels
{
    public class VKAuthVM : ViewModelBase
    {
        private readonly IVKAPIService vKAPIService;
        // Логин
        private string _login = null;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        // Пароль
        private string _password = null;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        // Оповещение
        private string _status; // Оповещение/ErrorMessage
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public ICommand VKAuthCommand { get; }
        public VKAuthVM() 
        {
            vKAPIService = new VKAPIService();
            VKAuthCommand = new ViewModelCommand(VKAuth);
        }
        private void VKAuth(object obj) // Авторизация через VKontakte
        {
            vKAPIService.VKAuth();
        }
    }
}
