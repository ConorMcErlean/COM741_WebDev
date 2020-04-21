using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SMS.Data.Models;

namespace SMS.Web.Models
{
    public class UserViewModel
    {  
        /// add validation attributes
        [Required]
        public string Name { get; set; } 
        [EmailAddress] [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare ("Password", ErrorMessage = 
        "Confirm password matches, Try again!")]
        public string PasswordConfirm  { get; set; }
        [Required]
        public Role Role { get; set; }

    }
}