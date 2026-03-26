using System;
using System.Collections.Generic;
using System.Text;
using TuWpf.Model;

namespace TuWpf.ViewModel
{
    internal class AdminViewModel
    {
        public AdminViewModel(UserRepositoryDb userRepository)
        {
            AllUserNames = userRepository.GetAllUserNames;
        }

        public IEnumerable<string> AllUserNames { get; set; }
    }
}
