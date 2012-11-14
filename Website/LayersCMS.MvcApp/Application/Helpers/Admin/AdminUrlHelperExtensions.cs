using System;
using System.Linq;
using System.Web.Mvc;

namespace LayersCMS.MvcApp.Application.Helpers.Admin
{
    public static class AdminUrlHelperExtensions
    {
        /// <summary>
        /// Returns true when the current controller executing the view matches the controllerName parameter (case insensitive).
        /// </summary>
        public static bool CurrentControllerIs(this UrlHelper helper, params string[] controllerNames)
        {
            string controller = helper.RequestContext.RouteData.Values["controller"].ToString();
            return
                controllerNames.Any(
                    x => string.Compare(controller, x, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
    }
}