using TuWpf.Others;

namespace TuWpf.Model
{
    public class UserRepository
    {
        private int _nextId;
        private List<User> _users { get; set; }

        public UserRepository()
        {
            _nextId = 0;
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void DeleteUser(int id)
        {
            var userIndex = _users.FindIndex(u => u.Id == id);
            if (userIndex != -1)
            {
                _users.RemoveAt(userIndex);
            }
        }

        public bool ValidateUesr(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == name && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password).FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password
                      select user;

            return ret.FirstOrDefault() != null ? true : false;
        }

        public User? GetUserByNameAndPassword(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password).FirstOrDefault();
        }

        public void SetUserActive(string name, DateTime validDate)
        {
            var user = _users.Where(x => x.Names == name).FirstOrDefault();
            if (user != null)
            {
                user.Expires = validDate;
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            var user = _users.Where(x => x.Names == name).FirstOrDefault();
            if (user != null)
            {
                user.Role = role;
            }
        }
    }
}
