using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using PrimeTableware.WPF.Models;
using PrimeTableware.WPF.Repositories;
using PrimeTableware.WPF.Repositories.Interfaces;
using PrimeTableware.WPF.ViewModels.Commands;
using PrimeTableware.WPF.Views;
using PrimeTableware.WPF.ViewModels;
using PrimeTableware.WPF.CustomControls.AddNew;
using PrimeTableware.WPF.CustomControls.Edit;
using System.Collections.ObjectModel;
using PrimeTableware.WPF.Views.NavigationPages;
using System.Collections;
using System.Windows.Input;

namespace PrimeTableware.WPF.ViewModels
{
    public class DataManageViewModel : ViewModelBase
    {
        private readonly IStaffRepository staffRepository;
        private readonly IUserRepository userRepository;
        private ObservableCollection<PositionModel> _positions;
        public ObservableCollection<PositionModel> Positions
        {
            get { return _positions; }
            set
            {
                _positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }

        private EmployeeViewModel _selectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        private ObservableCollection<EmployeeViewModel> _users;
        public ObservableCollection<EmployeeViewModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public ICommand EditOpenDialogCommand { get; }
        public ICommand SaveEditCommand { get; }
        public ICommand CloseEditDialogCommand { get; }
        public DataManageViewModel()
        {
            userRepository = new UserRepository();
            staffRepository = new StaffRepository();

            EditOpenDialogCommand = new RelayCommand(EditOpenCommandExecute);
            SaveEditCommand = new RelayCommand(SaveEditCommandExecute);
            CloseEditDialogCommand = new RelayCommand(CloseDialogCommandExecute);
            LoadData();
        }

        private EditStaffControl _editDialog;

        private void EditOpenCommandExecute(object selectedItem)
        {
            if (selectedItem is EmployeeViewModel selectedEmployee)
            {
                _editDialog = new EditStaffControl();
                _editDialog.DataContext = this;
                SelectedEmployee = selectedEmployee;

                var Positions =  staffRepository.GetAllPositions();
                var Users = userRepository.GetByAll();
                _editDialog.ShowDialog();
            }
        }

        private void SaveEditCommandExecute(object selectedItem)
        {
            if (selectedItem is EmployeeViewModel selectedEmployee)
            {
                var staffModel = new StaffModel
                {
                    idEmployee = selectedEmployee.idUser,
                    idUser = selectedEmployee.idUser,
                    idPosition = selectedEmployee.idPosition,
                    DateStarted = selectedEmployee.DateStarted.HasValue ? selectedEmployee.DateStarted.Value : DateTime.MinValue,
                    DateTerminated = selectedEmployee.DateTerminated.HasValue ? selectedEmployee.DateTerminated.Value : DateTime.MinValue,
                    DateEdit = DateTime.Now
                };

                // Вызов метода EditStaff непосредственно на ViewModel
                staffRepository.EditStaff(staffModel);

                _editDialog.Close();
            }
        }
        private void CloseDialogCommandExecute(object dialog)
        {
            if (dialog is Window window)
            {
                window.Close();
            }
        }

        private void LoadData() // Выводим 4 таблицы в одну
        {
            // Получение данных из репозиториев
            var staff = staffRepository.GetAllStaff();
            var users = userRepository.GetByAll();
            var departments = staffRepository.GetAllDepartments();
            var positions = staffRepository.GetAllPositions();

            // Создание коллекции EmployeeViewModel и заполнение ее данными
            var employeeViewModels = new ObservableCollection<EmployeeViewModel>();

            foreach (var staffModel in staff)
            {
                var user = users.FirstOrDefault(u => u.idUser == staffModel.idUser);
                var position = positions.FirstOrDefault(p => p.idPosition == staffModel.idPosition);
                var department = departments.FirstOrDefault(d => d.idDepartment == position?.idDepartment);

                var employeeViewModel = new EmployeeViewModel
                {
                    idUser = staffModel.idUser,
                    idPosition = staffModel.idPosition,
                    Login = user?.Login,
                    Name = user?.Name,
                    Surname = user?.Surname,
                    FName = user?.FName,
                    Mail = user?.Mail,
                    MobilePhone = user?.MobilePhone,
                    Adress = user?.Adress,
                    DateStarted = staffModel.DateStarted,
                    DateTerminated = staffModel.DateTerminated,
                    Salary = position?.Salary,
                    Position = position?.NamePosition,
                    NameDepartment = department?.NameDepartment
                };

                employeeViewModels.Add(employeeViewModel);
            }

            Users = employeeViewModels;
 
        }

    }
}