namespace TuWpf.Model
{
    public class UserLoginAttempt
    {
        private string _usernameEntered;
        private string _passwordEntered;
        private int _attemptCount;
        private UserRepository _userRepository;

        public UserLoginAttempt(string username, string password, UserRepository userRepository)
        {
            _usernameEntered = username;
            _passwordEntered = password;
            _userRepository = userRepository;
        }

        public int AttemptCount => _attemptCount;
        public string ErrorMessage { get; private set; }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(_usernameEntered) || string.IsNullOrEmpty(_passwordEntered))
            {
                ErrorMessage = "Username and password cannot be empty.";
                return false;
            }

            return true;
        }

        public bool AssertCredentials()
        {
            if (_userRepository.ValidateUserLambda(_usernameEntered, _passwordEntered))
            {
                return true;
            }

            ErrorMessage = "Invalid username or password.";
            return false;
        }

        public User ExecuteLoginUser()
        {
            var user = _userRepository.GetUserByNameAndPassword(_usernameEntered, _passwordEntered);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            return user;
        }
    }
}
