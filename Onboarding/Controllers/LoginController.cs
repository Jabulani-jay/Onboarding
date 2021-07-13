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
    public class LoginController : ControllerBase
    {
        private readonly IUser _UserRepository;
        public LoginController(IUser UserRepository)
        {
            _UserRepository = UserRepository;
        }
       


        [HttpGet]

        public User Login(string email, string password)
        {
            User userDetails;
            userDetails = _UserRepository.Login(email, password);
            return userDetails;
         }
    }
}
