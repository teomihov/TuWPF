using TuWpf.Model;
using TuWpf.Others;
using TuWpf.View;
using TuWpf.ViewModel;
using static WelcomeExtended.Others.Delegates;

namespace WelcomeExtended
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var user = new User
                {
                    Names = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT,
                };
                var viewModel = new UserViewModel(user);

                var w = new MainWindow(viewModel);
                w.ShowDialog();

                throw new InvalidOperationException("Just to test the logs");
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Application has ended.");
            }
        }
    }
}
