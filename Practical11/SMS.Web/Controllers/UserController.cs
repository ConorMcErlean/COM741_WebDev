using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using SMS.Data.Services;
using SMS.Data.Models;
using SMS.Web.Models;

namespace SMS.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IStudentService _svc;

        public UserController()
        {
            _svc = new StudentService();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("EmailAddress,Password")]UserViewModel m)
        {   
            // call service to Autheticate User
            var user = _svc.Authenticate(m.EmailAddress, m.Password);  
            
            // verify if user found and if not then add a model state e
            if (user == null)
            {
                ModelState.AddModelError("EmailAddress", "Invalid Login Credentials");
                ModelState.AddModelError("Password", "Invalid Login Credentials");
                return View(m);
            }  
               
            // sign user in using cookie authentication to store principal
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                BuildClaimsPrincipal(user)
            );
            return RedirectToAction("Index","Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        // Use antiforgery token and Bind attribute for UserViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]         
        public IActionResult Register([Bind("Name", "VerifyEmailAddress", "Password", 
                        "Role")] UserViewModel m) 
        {
            // if not valid model
            //    return View(m) to redisplay the view with validation errors
            if(ModelState.IsValid == false)
            {
                return View(m);
            }// endif                               

            // call service to register user
            var user = _svc.RegisterUser(m.Name, m.EmailAddress, m.Password, m.Role);
            
            // if user returned is null then 
            if (user ==null)
            {
                 //    add a modelstate error as emailaddress must already be registered
                 ModelState.AddModelError("EmailAddress", "EmailAddress has already been used" +
                            ". Choose another");
                //   (see how this is done in login above) and return the view for editing  
                return View(m);
            }// endif 

            // Add alert indicating registration successful and redirect to login page
                Alert("Registration Successful - Now Login", AlertType.info);
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ErrorNotAuthorised()
        {   
            Alert("Not Authorized", AlertType.warning);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ErrorNotAuthenticated()
        {
            Alert("Not Authenticated", AlertType.warning);
            return RedirectToAction("Login", "User"); 
        }

        // Build a claims principal from authenticated user
        private  ClaimsPrincipal BuildClaimsPrincipal(User user)
        { 
            // define user claims
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())                              
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            // build principal using claims
            return  new ClaimsPrincipal(claims);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmailAddress(string email)
        {
            if (_svc.GetUserByEmailAddress(email) != null)
            {
                return Json($"Email Address {email} is already in use. Please choose another");
            }
            return Json(true);
        }

    }
}
