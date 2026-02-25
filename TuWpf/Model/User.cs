using TuWpf.Others;

namespace TuWpf.Model
{
    public class User
    {
        public string Names { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int FailedLoginAttempts { get; set; }

        public bool IsAdmin => Role == "admin";
        public bool FailedPasswordAttemptsExceededLimit => FailedLoginAttempts >= 5;
    }
}
