using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Data.Persistence.Models.Pages;
using LayersCMS.Web.Controllers;

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
                ViewBag.HasSubPages = _cmsPageReads.GetCollectionForParent(cmsPage.Id).Any();
                return View("CmsPage", cmsPage);                
            }

            // Page must not be published. Return a 404.
            return PageNotFound();
        }

        [ChildActionOnly]
        public ActionResult RootNavigation()
        {
            IEnumerable<NavigationPageDetails> model = _cmsPageReads.GetForNavigation();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult SubNavigation()
        {
            // Retrieve the page from the database
            LayersCmsPage cmsPage = _cmsPageReads.GetByUrl(Request.Url.LocalPath);

            // If the page is null, no match found for url, return 404
            if (cmsPage == null)
            {
                return null;
            }

            if (cmsPage.ParentId != null)
            {
                // Get the parent page
                LayersCmsPage parentPage = _cmsPageReads.GetById(cmsPage.ParentId.Value);

                // If the page is null, no match found for url, return 404
                if (parentPage != null)
                {
                    cmsPage = parentPage;
                }
            }
            

            // Get the collection of sub/child pages
            IEnumerable<NavigationPageDetails> childPages = _cmsPageReads.GetForNavigation(cmsPage.Id);

            if (childPages == null)
            {
                // Don't show the sub nav if there aren't any child pages
                return null;
            }

            return PartialView(new SubNavigationModel()
                {
                    ChildPages = _cmsPageReads.GetForNavigation(cmsPage.Id),
                    ParentPage = cmsPage
                });
        }

    }
}
