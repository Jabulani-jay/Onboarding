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
    public class UserController : ControllerBase
    {
        private readonly IUser _UserRepository;
        public UserController(IUser UserRepository)
        {
            _UserRepository = UserRepository;
        }
        [HttpGet]
        public bool RegisterUser(string firstname, string lastname, string email, string Password)
        {
            User NewUser = new();
            NewUser.Firstname = firstname;
            NewUser.Lastname = lastname;
            NewUser.UserEmail = email;
            NewUser.Password = Password;

           return _UserRepository.RegisterUser(NewUser);
        }

        //[HttpGet]

        //public User Login(string email, string password)
        //{
        //    User userDetails;
        //    userDetails = _UserRepository.Login(email, password);
        //    return userDetails;
        //}
    }
}
