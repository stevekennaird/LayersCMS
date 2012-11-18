using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.MvcApp.Areas.Admin.Models.Users
{
    public class AddUserModel
    {
        [Required, Display(Name = "Email Address"), EmailAddress, StringLength(250)]
        public virtual String EmailAddress { get; set; }
        
        [Required, StringLength(50)]
        public virtual String Password { get; set; }

        [Required, StringLength(50), Compare("Password", ErrorMessage = "The two passwords must match")]
        public virtual String ConfirmPassword { get; set; }
    }
}