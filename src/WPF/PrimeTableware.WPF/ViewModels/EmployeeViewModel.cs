using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTableware.WPF.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private int _idUser;
        public int idUser
        {
            get { return _idUser; }
            set
            {
                _idUser = value;
                OnPropertyChanged(nameof(idUser));
            }
        }
        private int _idPosition;
        public int idPosition
        {
            get { return _idPosition; }
            set
            {
                _idPosition = value;
                OnPropertyChanged(nameof(idPosition));
            }
        }

        private string _userLogin;
        public string Login
        {
            get { return _userLogin; }
            set
            {
                _userLogin = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _userName;
        public string Name
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string _fName;
        public string FName
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropertyChanged(nameof(FName));
            }
        }

        private string _mobilePhone;
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set
            {
                _mobilePhone = value;
                OnPropertyChanged(nameof(MobilePhone));
            }
        }
        private string _mail;
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }

        private string _adress;
        public string Adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }

        private DateTime? _employeeDateStarted;
        public DateTime? DateStarted
        {
            get { return _employeeDateStarted; }
            set
            {
                _employeeDateStarted = value;
                OnPropertyChanged(nameof(DateStarted));
            }
        }
        private DateTime? _employeeDateTerminated;
        public DateTime? DateTerminated
        {
            get { return _employeeDateTerminated; }
            set
            {
                _employeeDateTerminated = value;
                OnPropertyChanged(nameof(DateTerminated));
            }
        }

        private decimal? _salary;
        public decimal? Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }

        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        private string _department;
        public string NameDepartment
        {
            get { return _department; }
            set
            {
                _department = value;
                OnPropertyChanged(nameof(NameDepartment));
            }
        }
    }
}
