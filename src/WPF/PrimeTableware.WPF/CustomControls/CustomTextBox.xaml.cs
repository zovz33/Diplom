using System.Windows;
using System.Windows.Controls;
 

namespace PrimeTableware.WPF.CustomControls
{
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
 
        }


        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }

        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.Register("HintText", typeof(string), typeof(CustomTextBox));

       
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(CustomTextBox),
                new FrameworkPropertyMetadata(string.Empty));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}