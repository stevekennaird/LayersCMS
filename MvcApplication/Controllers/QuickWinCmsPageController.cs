using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickWin.Cms.Data.Domain.Pages;
using QuickWin.Cms.Data.Persistence.Interfaces.Reads;

namespace MvcApplication.Controllers
{
    public class QuickWinCmsPageController : Controller
    {
        #region Constructor and Dependencies

        private readonly IQuickWinPageReads _cmsPageReads;

        public QuickWinCmsPageController(IQuickWinPageReads cmsPageReads)
        {
            _cmsPageReads = cmsPageReads;
        }

        #endregion

        public ActionResult HandleUrl(String url)
        {
            // Retrieve the page from the database
            QuickWinPage cmsPage = _cmsPageReads.GetByUrl(url, true);

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
