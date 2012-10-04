using System;
using System.ComponentModel.DataAnnotations;
using QuickWin.MvcApp.Application.Validation;

namespace QuickWin.MvcApp.Models.ContactUs
{
    public class ContactUsModel
    {
        #region Form Fields

        [Required, StringLength(50), Display(Name = "First Name")]
        public virtual String FirstName { get; set; }

        [Required, StringLength(50), Display(Name = "Last Name")]
        public virtual String LastName { get; set; }

        [Required, StringLength(250), EmailAddress, Display(Name = "Email Address")]
        public virtual String EmailAddress { get; set; }

        [StringLength(50), Display(Name = "Telephone Number")]
        public virtual String TelephoneNumber { get; set; }

        [Required, StringLength(5000)]
        public virtual String Message { get; set; }

        #endregion

        #region Spam Prevention

        [HoneyPot, Display(Name = "Date of Birth")]
        public virtual String Dob { get; set; }

        public virtual DateTime DateFormLoaded { get; set; }

        #endregion
    }
}