using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _AdminRepository;
        public AdminController(IAdmin AdminRepository)
        {
            _AdminRepository = AdminRepository;
        }

        [HttpPost("Deactivate User")]
        public string DeactivateUser(int id)
        {

            return _AdminRepository.DeactivateUser(id);
        }

        [HttpPost("activate User")]
        public string ActivateUser(int id)
        {

            return _AdminRepository.activateUser(id);
        }
        [HttpGet("Get Cohort")]
        public string GetCohort()
        {

            return _AdminRepository.GetCohort();
        }
    }
}
