using System.ComponentModel.DataAnnotations;

namespace SMS.Rest.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string EmailAddress { get; set; }    
        [Required]
        public string Password { get; set; }
    }
}