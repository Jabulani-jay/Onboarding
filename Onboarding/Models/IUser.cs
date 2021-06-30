using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public interface IUser
    {
        public bool RegisterUser(User newUser);

        public User Login(string email, string password);
    }
}
