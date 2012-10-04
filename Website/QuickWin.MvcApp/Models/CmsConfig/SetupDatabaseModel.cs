using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuickWin.MvcApp.Models.CmsConfig
{
    public class SetupDatabaseModel
    {
        [Required, Display(Name = "Connection String")]
        public String ConnectionStringName { get; set; }
        
        [Required, EmailAddress, Display(Name = "Admin Email Address")]
        public String UserEmailAddress { get; set; }

        [Required, StringLength(30, MinimumLength = 8), Display(Name = "Admin Password")]
        public String UserPassword { get; set; }

        public IEnumerable<SelectListItem> ConnectionStringOptions { get; set; }
    }
}