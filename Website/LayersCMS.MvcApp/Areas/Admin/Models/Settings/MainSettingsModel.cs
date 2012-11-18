using System;
using System.ComponentModel.DataAnnotations;

namespace LayersCMS.MvcApp.Areas.Admin.Models.Settings
{
    public class MainSettingsModel
    {
        public virtual Boolean SavedSuccessfully { get; set; }

        [Required, EmailAddress, Display(Name = "Email address"), StringLength(200)]
        public virtual String ContactEmailAddress { get; set; }

        [Required, Display(Name = "Phone number"), StringLength(50)]
        public virtual String ContactPhoneNumber { get; set; }

        [Display(Name = "Google Analytics UA #"), StringLength(15)]
        public virtual String GoogleAnalyticsAccountId { get; set; }
    }
}