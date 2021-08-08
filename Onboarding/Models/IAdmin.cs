using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public interface IAdmin
    {
        public string AddEmail(string email, int adminId);
        public string DeactivateUser(int userId, int adminId);
        public string activateUser(int userId, int adminId);
        public string GetCohort(int adminId);
    }
}
