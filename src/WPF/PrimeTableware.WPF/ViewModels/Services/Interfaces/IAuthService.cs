using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories;
using PrimeTableware.WPF.ViewModels.AttachedProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeTableware.WPF.ViewModels.Services
{
    public interface IAuthService
    {
        bool IsLoggedIn { get; }
    //    void Login(string username, SecureString password);
        void Logout();
    }
}
