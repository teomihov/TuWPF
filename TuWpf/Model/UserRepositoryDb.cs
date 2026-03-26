using System;
using System.Collections.Generic;
using System.Text;
using TuWpf.Model.Database;

namespace TuWpf.Model
{
    public class UserRepositoryDb : UserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepositoryDb()
        {
            _dbContext = new DatabaseContext();
            _users = _dbContext.Users.ToList();
        }

        public IEnumerable<string> GetAllUserNames => _users.Select(x => x.Names);

        public void CreateDatabase()
        {
            _dbContext.Database.EnsureCreated();
        }
    }
}
