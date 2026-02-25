using TuWpf.Model;

namespace TuWpf.ViewModel
{
    class UserViewModel
    {
        private User _user;
        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Names
        {
            get => _user.Names;
            set { _user.Names = value; }
        }

        public string Password
        {
            get => _user.Password;
            set { _user.Password = value; }
        }

        public string Email
        {
            get => _user.Email;
            set { _user.Email = value; }
        }

        public string Role
        {
            get => _user.Role;
            set { _user.Role = value; }
        }
         public bool IsAdmin => _user.IsAdmin;
         public bool FailedPasswordAttemptsExceededLimit => _user.FailedPasswordAttemptsExceededLimit;
    }
}
