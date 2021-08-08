using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public interface IAuth
    {
        public bool IsAdmin(int role);
    }
}
