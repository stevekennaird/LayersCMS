using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.MvcApp.Areas.Admin.Controllers.Base;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class PagesController : LayersCmsAdminController
    {
        #region Constructor and Dependencies
        private readonly ILayersCmsPageReads _pageReads;

        public PagesController(ILayersCmsPageReads pageReads)
        {
            _pageReads = pageReads;
        }

        #endregion


        [GET("pages")]
        public ActionResult List()
        {
            IEnumerable<LayersCmsPage> rootLevelPages = _pageReads.GetCollectionForParent(null);
            return View(rootLevelPages);
        }

        [GET("pages/add")]
        public ActionResult Add()
        {
            return View();
        }

    }
}
