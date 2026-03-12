using System.Configuration;
using System.Data;
using System.Windows;
using TuWpf.Model;
using TuWpf.View;
using TuWpf.ViewModel;

namespace TuWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var userRepository = new UserRepository();

            var user = new User
            {
                Email = "test@test.bg",
                FailedLoginAttempts = 2,
                Names = "test",
                Password = "test",
            };
            userRepository.AddUser(user);

            var loginViewModel = new LoginViewModel(userRepository);
            var loginWindow = new LoginWindow(loginViewModel);
            loginWindow.Show();
        }
    }
}
