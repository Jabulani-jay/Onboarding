using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public string RegisterUser(User NewUser)
        {
            return _UserRepository.RegisterUser(NewUser);
        }

        [HttpPost("UpdateUser")]
        public User UpdateUser(User user)
        {
            return _UserRepository.updateUserInfo(user);
        }

        [HttpPost("Reset password")]
        public string ResetPassword(string email, string password)
        {
            return _UserRepository.PasswordReset(email, password);
        }

        [HttpPost("ImageUpload")]

        public string UploadImage([FromForm] ProfileImage profileImage)
        {
            ProfileImageDetails profileImageDetails = new ProfileImageDetails();
            profileImageDetails.UserId = profileImage.UserId;
            profileImageDetails.files = profileImage.files;
            profileImageDetails.FilePath = "/ProfileImages/"+profileImage.UserId + Path.GetExtension(profileImage.files.FileName);
            return _UserRepository.UploadImage(profileImageDetails);
        }

        [HttpPost("ImageUrl")]

        public string getURL(int id)
        {
            return _UserRepository.GetImageUrl(id);
        }
    }
}
