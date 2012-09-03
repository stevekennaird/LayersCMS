using System;
using System.ComponentModel.DataAnnotations;
using MvcApplication.Application.Validation;

namespace MvcApplication.Models.ContactUs
{
    public class ContactUsModel
    {
        #region Form Fields

        [Required, MaxLength(50)]
        public virtual String FirstName { get; set; }

        [Required, MaxLength(50)]
        public virtual String LastName { get; set; }

        [Required, MaxLength(250), EmailAddress]
        public virtual String EmailAddress { get; set; }

        [MaxLength(50)]
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