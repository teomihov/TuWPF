using TuWpf.Others;

namespace TuWpf.Model
{
    public class UserRepository
    {
        private int _nextId;
        protected IEnumerable<User> _users { get; set; }

        public UserRepository()
        {
            _nextId = 0;
            _users = new List<User>();
        }

        public virtual void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Append(user);
        }

        public virtual void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users = _users.Where(user => user.Id != id);
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
