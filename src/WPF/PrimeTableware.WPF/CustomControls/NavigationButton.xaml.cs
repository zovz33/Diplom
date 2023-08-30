using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimeTableware.WPF.CustomControls
{
    public partial class NavigationButton : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(NavigationButton));
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(MahApps.Metro.IconPacks.PackIconMaterialKind), typeof(NavigationButton));
        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(NavigationButton));
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(NavigationButton));
        public NavigationButton()
        {
            InitializeComponent();
        }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public MahApps.Metro.IconPacks.PackIconMaterialKind Icon
        {
            get { return (MahApps.Metro.IconPacks.PackIconMaterialKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }

        }
       
    }
}