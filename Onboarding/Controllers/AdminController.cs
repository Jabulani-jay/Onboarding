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
        private readonly IAuth _AdminDictionary;
        public AdminController(IAdmin AdminRepository, IAuth AdminDictionary)
        {
            _AdminRepository = AdminRepository;
            _AdminDictionary = AdminDictionary;
        }
        [HttpPost("AddUserEmail")]
        public string AddEmail(string email, int adminId, int role)
        {

            if (_AdminDictionary.IsAdmin(role))
            {
                string message = _AdminRepository.AddEmail(email, adminId);
                return message;
            }
            else return "User not allowed to perfom this action";

        }
        [HttpPost("DeactivateUser")]
        public string DeactivateUser(int userId, int adminId, int role)
        {
            if (_AdminDictionary.IsAdmin(role))
            {
                return _AdminRepository.DeactivateUser(userId, adminId);
            }
            else return "User not allowed to perfom this action";
        }

        [HttpPost("ActivateUser")]
        public string ActivateUser(int userId, int adminId, int role)
        {
            if (_AdminDictionary.IsAdmin(role))
            {
                return _AdminRepository.activateUser(userId, adminId);

            }
            else return "User not allowed to perfom this action";
        }
        [HttpGet("GetCohort")]
        public string GetCohort(int adminId, int role)
        {
            if (_AdminDictionary.IsAdmin(role))
            {
                return _AdminRepository.GetCohort(adminId);
            }
            else return "User not allowed to perfom this action";
        }
    }
}
