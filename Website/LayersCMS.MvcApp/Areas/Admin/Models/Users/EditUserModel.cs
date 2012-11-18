using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.MvcApp.Areas.Admin.Models.Users
{
    public class EditUserModel
    {
        public virtual Int32 Id { get; set; }

        [Required, Display(Name = "Email Address"), EmailAddress, StringLength(250)]
        public virtual String EmailAddress { get; set; }
        
        [StringLength(50)]
        public virtual String Password { get; set; }

        [StringLength(50), Compare("Password", ErrorMessage = "The two passwords must match")]
        public virtual String ConfirmPassword { get; set; }

        public virtual Boolean Active { get; set; }


        public virtual Boolean BothPasswordsEntered { get { return !String.IsNullOrWhiteSpace(Password) && !String.IsNullOrWhiteSpace(ConfirmPassword); } }
    }
}