using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.MvcApp.Areas.Admin.Controllers.Base;
using LayersCMS.MvcApp.Areas.Admin.Models.Auth;
using System.Web.Mvc;
using System.Web.Security;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class AuthController : LayersCmsAdminController
    {
        #region Constructor and Dependencies

        public AuthController(ILayersCmsUserReads userReads) : base(userReads) { }

        #endregion

        [GET("login"), AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [POST("login"), AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            // Check the posted model is valid
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    // The member has been validated, so sign them in using the FormsAuthentication framework
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    // If a returnUrl has been specified in the querystring, redirect the user to that url
                    // as long as it's a relative url
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    // If no returnUrl has been specified, redirect to the default page in the admin area
                    return RedirectToAction("List", "Pages");
                }

                // Membership validation failed, display the error message
                ModelState.AddModelError("", "The email address or password provided is incorrect, or your account is inactive.");
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
