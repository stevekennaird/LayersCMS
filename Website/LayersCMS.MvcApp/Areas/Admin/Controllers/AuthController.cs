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

        [POST("login"), AllowAnonymous]
        public ActionResult Login(object model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                /*if (Membership.ValidateUser(model.EmailAddress, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.EmailAddress, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError("", "The email address or password provided is incorrect, or your account is inactive.");*/
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [GET("logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
