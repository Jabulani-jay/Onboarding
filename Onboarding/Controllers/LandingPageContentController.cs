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
    public class LandingPageContentController : ControllerBase
    {
        private readonly ILandingPage _landingPageRepository;
        public LandingPageContentController(ILandingPage landingPageRepository)
        {
            _landingPageRepository = landingPageRepository;
        }

        [HttpGet]

        public LandingPage LandingAction()
        {
            return _landingPageRepository.landingPageContent();
        }
    }
}
