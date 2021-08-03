using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public interface IAdmin
    {
        public string DeactivateUser(int id);
        public string activateUser(int id);

    }
}
