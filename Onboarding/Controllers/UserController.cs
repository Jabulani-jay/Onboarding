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
        public IWebHostEnvironment _hostingEnvironment;
        public UserController(IUser UserRepository, IWebHostEnvironment hostingEnvironment)
        {
            _UserRepository = UserRepository;
            _hostingEnvironment = hostingEnvironment;
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

        public async Task<string> uploadImage([FromForm] ProfileImage profileImage)
        {
            if (profileImage.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_hostingEnvironment.WebRootPath + "\\ProfileImages\\"))
                    {
                        Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "\\ProfileImages\\");
                    }
                    string name = profileImage.files.FileName;

                    using (FileStream fileStream = System.IO.File.Create(_hostingEnvironment.WebRootPath + "\\ProfileImages\\" + profileImage.UserId+Path.GetExtension(name)))
                    {
                        profileImage.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\ProfileImages\\" + profileImage.files.FileName;
                    }

                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
            else return "failed to upload";
        }
    }
}
