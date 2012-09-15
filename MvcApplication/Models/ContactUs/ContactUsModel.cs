using System;
using System.ComponentModel.DataAnnotations;
using QuickWin.MvcApplication.Application.Validation;

namespace QuickWin.MvcApplication.Models.ContactUs
{
    public class ContactUsModel
    {
        #region Form Fields

        [Required, MaxLength(50), Display(Name = "First Name")]
        public virtual String FirstName { get; set; }

        [Required, MaxLength(50), Display(Name = "Last Name")]
        public virtual String LastName { get; set; }

        [Required, MaxLength(250), EmailAddress, Display(Name = "Email Address")]
        public virtual String EmailAddress { get; set; }

        [MaxLength(50), Display(Name = "Telephone Number")]
        public virtual String TelephoneNumber { get; set; }

        [Required, MaxLength(5000)]
        public virtual String Message { get; set; }

        #endregion

        #region Spam Prevention

        [HoneyPot, Display(Name = "Date of Birth")]
        public virtual String Dob { get; set; }

        public virtual DateTime DateFormLoaded { get; set; }

        #endregion
    }
}