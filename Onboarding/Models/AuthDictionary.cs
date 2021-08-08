using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class AdminDictionary : IAuth
    {
        public bool IsAdmin(int role)
        {
            if (role == 1)
            {
                return true;
            }
            else return false;
        }
    }
}
