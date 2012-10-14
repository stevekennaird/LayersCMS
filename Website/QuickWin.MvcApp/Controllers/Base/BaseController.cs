using System;
using System.Net;
using System.Web.Mvc;
using LayersCMS.MvcApp.Application.Config;

namespace LayersCMS.MvcApp.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        #region Constructor and Fields

        internal readonly ApplicationConfigurationHelper ConfigurationHelper;

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
