using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.MvcApp.Areas.Admin.Controllers.Base;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class AuthController : LayersCmsAdminController
    {
        #region Constructor and Dependencies

        /*private readonly ILayersCmsUserReads _userReads;

        public AuthController(ILayersCmsUserReads userReads)
        {
            _userReads = userReads;
        }*/

        #endregion  

        [GET("login"), AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [GET("logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
