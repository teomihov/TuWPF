using System;
using System.Collections.Generic;
using System.Text;
using TuWpf.Model;
using TuWpf.View;

namespace TuWpf.ViewModel
{
    public class LoginViewModel
    {
        private UserLoginAttempt _userLoginAttempt;
        private UserRepository _userRepository;


        public LoginViewModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserLoginAttempt? UserLoginAttempt => _userLoginAttempt;
        public string ErrorMessage => _userLoginAttempt?.ErrorMessage ?? string.Empty;

        public string UserNameText { get; set; }
        public string PasswordText { get; set; }

        public string LoginExecute()
        {
            _userLoginAttempt = new UserLoginAttempt(UserNameText, PasswordText, _userRepository);

            if (!_userLoginAttempt.Validate())
            {
                return _userLoginAttempt.ErrorMessage;
            }

            if(!_userLoginAttempt.AssertCredentials())
            {
                return _userLoginAttempt.ErrorMessage;
            }

            var user = _userLoginAttempt.ExecuteLoginUser();
            var userViewModel = new UserViewModel(user);
            var mainWindow = new MainWindow(userViewModel);

            mainWindow.DisplayUserInfo();
            mainWindow.Show();

            return "Login successful!";
        }
    }
}
