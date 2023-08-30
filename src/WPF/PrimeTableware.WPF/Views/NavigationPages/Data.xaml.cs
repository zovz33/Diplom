using System.Windows.Controls;
using System.Windows.Input;
using PrimeTableware.WPF.ViewModels;

namespace PrimeTableware.WPF.Views.NavigationPages
{
    public partial class Data : Page
    {
        public Data()
        {
            InitializeComponent();
        }
        private void ViewAllUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItem is EmployeeViewModel selectedEmployee)
            {
                var viewModel = (DataManageViewModel)DataContext;
                viewModel.EditOpenDialogCommand.Execute(selectedEmployee);
            }
        }
    }
}
