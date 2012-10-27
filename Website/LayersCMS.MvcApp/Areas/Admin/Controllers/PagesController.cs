using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using LayersCMS.MvcApp.Areas.Admin.Controllers.Base;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class PagesController : LayersCmsAdminController
    {
        [GET("pages")]
        public ActionResult List()
        {
            return View();
        }

    }
}
