using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public interface IUser
    {
        public string RegisterUser(User newUser);

        public User Login(string email, string password);

        public string PasswordReset(string email, string password);

        public User updateUserInfo(User details);
    }
}
