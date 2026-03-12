using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TuWpf.ViewModel;

namespace TuWpf.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel _loginViewModel;

        public LoginWindow(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _loginViewModel.UserNameText = textBoxUserName.Text;
            _loginViewModel.PasswordText = textBoxPassword.Text;
            var result = _loginViewModel.LoginExecute();

            MessageBox.Show(result);
        }
    }
}
