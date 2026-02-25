using System.Windows;
using System.Windows.Controls;
using TuWpf.ViewModel;

namespace TuWpf.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : Window
    {
        private UserViewModel _userViewModel;

        internal MainWindow(UserViewModel userViewModel)
        {
            _userViewModel = userViewModel;
            InitializeComponent();
        }

        public void DisplayUserInfo()
        {
            var textBlockUser = new TextBlock();
            textBlockUser.Text = $"Names: {_userViewModel.Names}\n" +
                                 $"Email: {_userViewModel.Email}\n" +
                                 $"Role: {_userViewModel.Role}\n" +
                                 $"Is Admin: {_userViewModel.IsAdmin}\n" +
                                 $"Failed Login Attempts Exceeded Limit: {_userViewModel.FailedPasswordAttemptsExceededLimit}";

            this.Content = textBlockUser;
        }
    }
}