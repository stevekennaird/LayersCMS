using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class CmsConfigController : Controller
    {
        [GET("cms-config/initial-setup")]
        public ActionResult SetupDatabase()
        {
            // Include a ReCaptcha on this page to prevent attack attempts
            return View();
        }

        [POST("cms-config/initial-setup")]
        public ActionResult SetupDatabase(Object model) // The model should obviously be a proper class
        {
            if (ModelState.IsValid)
            {
                // Check the key entered equals AppSettings[""],
                // if so, run new DatabaseSchemaSetup(..).Initialise(.., ..);
                // Then redirect to SetupDatabaseComplete action
            }
            return View();
        }

        [GET("cms-config/initial-setup/complete")]
        public ActionResult SetupDatabaseComplete(bool success, string error = null)
        {
            return View();
        }

    }
}
