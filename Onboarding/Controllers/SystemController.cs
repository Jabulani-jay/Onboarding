using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ISystem _systemDictionary;
        private readonly IAuth _AuthDictionary;
        public SystemController(ISystem SystemDictionary, IAuth auth)
        {
            _systemDictionary = SystemDictionary;
            _AuthDictionary = auth;
        }

        [HttpGet("getLog")]
        public string getCohort(int adminId, int role)
        {
            if (_AuthDictionary.IsAdmin(role))
            {
                return _systemDictionary.GetLog(adminId);

            }
            else return "User not allowed to perfom this action";

        }
    }
}
