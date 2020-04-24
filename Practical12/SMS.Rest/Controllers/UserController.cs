using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SMS.Data.Services;
using SMS.Rest.Helpers;
using SMS.Rest.Models;
using SMS.Data.Models;

using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace SMS.Rest.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IStudentService _svc;

        public UserController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _svc = new StudentService();
        }

        public IActionResult GetAllUsers()
        {
            return  Ok(_svc.GetAllUsers());
        }

        // POST api/user/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<User> Authenticate(AuthenticateModel model)        
        {         
            var user = _svc.Authenticate(model.EmailAddress, model.Password);            
            if (user == null)
            {
                return BadRequest(new { message = "EmailAddress or Password is incorrect" });
            }
            return JwtHelper.SignJwtToken(user, _appSettings.Secret);
        }

    }
}
