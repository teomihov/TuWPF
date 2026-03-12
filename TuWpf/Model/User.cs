using TuWpf.Others;

namespace TuWpf.Model
{
    public class User
    {
        public int Id { get; set; }
        public DateTime Expires { get; set; }
        public string Names { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRolesEnum Role { get; set; }
        public int FailedLoginAttempts { get; set; }

        public bool IsAdmin => Role == UserRolesEnum.ADMIN;
        public bool FailedPasswordAttemptsExceededLimit => FailedLoginAttempts >= 5;
    }
}
