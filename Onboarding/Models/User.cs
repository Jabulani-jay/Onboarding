using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string UserEmail { get; set; }

        public string Password{ get; set; }
    }
}
