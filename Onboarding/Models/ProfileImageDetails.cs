using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class ProfileImageDetails:ProfileImage
        
    {
        
        public string FilePath { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
