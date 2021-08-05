using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public interface IAdmin
    {
        public string AddEmail(string email);
        public string DeactivateUser(int id);
        public string activateUser(int id);

        public string GetCohort();


    }
}
