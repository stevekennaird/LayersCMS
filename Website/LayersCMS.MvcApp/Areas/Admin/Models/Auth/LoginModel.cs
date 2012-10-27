using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.MvcApp.Areas.Admin.Models.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a username"), 
        EmailAddress(ErrorMessage = "The username should be a valid email address")]
        public virtual String Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public virtual String Password { get; set; }

        public virtual Boolean RememberMe { get; set; }
    }
}