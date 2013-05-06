using System;
using System.Net;
using System.Web.Mvc;
using LayersCMS.Web.Config;

namespace LayersCMS.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Constructor and Fields

        public readonly ApplicationConfigurationHelper ConfigurationHelper;

        protected BaseController()
        {
            ConfigurationHelper = new ApplicationConfigurationHelper();
        }

        #endregion

        #region Reusable Actions

        public ActionResult PageNotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View("PageNotFound");
        }

        public ActionResult ServerError(String msg = null)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ViewBag.Message = msg;
            return View("ServerError");
        }

        #endregion

    }
}
