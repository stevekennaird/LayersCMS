using System;
using System.Web.Mvc;
using LayersCMS.Data.Domain.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads;

namespace LayersCMS.MvcApp.Controllers
{
    public class LayersCmsPageController : Controller
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
            LayersCmsPage cmsPage = _cmsPageReads.GetByUrl(url, true);

            // If the page is null, no match found for url, return 404
            if (cmsPage == null)
            {
                return new HttpNotFoundResult();
            }

            // Check whether a redirect has been added for this page
            if (cmsPage.RedirectType != RedirectTypeEnum.None && !String.IsNullOrWhiteSpace(cmsPage.RedirectUrl))
            {
                return cmsPage.RedirectType == RedirectTypeEnum.Temporary
                           ? Redirect(cmsPage.RedirectUrl)
                           : RedirectPermanent(cmsPage.RedirectUrl);
            }

            return View(cmsPage);
        }

    }
}
