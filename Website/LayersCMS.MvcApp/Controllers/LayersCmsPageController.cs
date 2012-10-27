using System;
using System.Web.Mvc;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.MvcApp.Controllers.Base;

namespace LayersCMS.MvcApp.Controllers
{
    public class LayersCmsPageController : BaseController
    {
        #region Constructor and Dependencies

        private readonly ILayersCmsPageReads _cmsPageReads;

        public LayersCmsPageController(ILayersCmsPageReads cmsPageReads)
        {
            _cmsPageReads = cmsPageReads;
        }

        #endregion

        public ActionResult HandleUrl(String url)
        {
            // Retrieve the page from the database
            LayersCmsPage cmsPage = _cmsPageReads.GetByUrl(url);

            // If the page is null, no match found for url, return 404
            if (cmsPage == null)
            {
                return PageNotFound();
            }

            // Check whether a redirect has been added for this page
            if (cmsPage.RedirectTypeEnum != RedirectTypeEnum.None && !String.IsNullOrWhiteSpace(cmsPage.RedirectUrl))
            {
                return cmsPage.RedirectTypeEnum == RedirectTypeEnum.Temporary
                           ? Redirect(cmsPage.RedirectUrl)
                           : RedirectPermanent(cmsPage.RedirectUrl);
            }

            if (cmsPage.IsPublished)
            {
                // Page is published, can display it. Render the view.
                return View("CmsPage", cmsPage);                
            }

            // Page must not be published. Return a 404.
            return PageNotFound();
        }

    }
}
