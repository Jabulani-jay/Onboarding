﻿using Microsoft.AspNetCore.Http;
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
       


        [HttpGet("Login")]
        public User Login(string email, string password)
        {
            User userDetails;
            userDetails = _UserRepository.Login(email, password);
            return userDetails;
         }

        [HttpPost("Register user")]
        public bool RegisterUser(User NewUser)
        {
            return _UserRepository.RegisterUser(NewUser);
        } 
    }
}
