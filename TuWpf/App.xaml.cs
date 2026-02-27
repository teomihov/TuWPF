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

            var user = new User
            {
                Email = "test@test.bg",
                FailedLoginAttempts = 2,
                Names = "Test User",
                Password = "pass",
            };
            var userViewModel = new UserViewModel(user);
            var mainWindow = new MainWindow(userViewModel);
            mainWindow.DisplayUserInfo();
            mainWindow.Show();
        }
    }
}
