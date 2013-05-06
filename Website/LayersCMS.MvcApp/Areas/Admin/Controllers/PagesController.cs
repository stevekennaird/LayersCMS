using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Data.Persistence.Interfaces.Writes;
using LayersCMS.MvcApp.Areas.Admin.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LayersCMS.Web.Controllers;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class PagesController : LayersCmsAdminController
    {
        #region Constructor and Dependencies
        private readonly ILayersCmsPageReads _pageReads;
        private readonly ILayersCmsPageWrites _pageWrites;

        public PagesController(ILayersCmsPageReads pageReads, 
                                ILayersCmsPageWrites pageWrites,
                                ILayersCmsUserReads userReads)
                                : base(userReads)
        {
            _pageReads = pageReads;
            _pageWrites = pageWrites;
        }

        #endregion

        #region Actions

        [GET("pages")]
        public ActionResult List()
        {
            IEnumerable<LayersCmsPage> rootLevelPages = _pageReads.GetCollectionForParent(null);
            return View(rootLevelPages);
        }

        [GET("pages/delete/{id}")]
        public ActionResult Delete(int id)
        {
            LayersCmsPage pageToDelete = _pageReads.GetById(id);

            // Return to the list page if the id is invalid
            if (pageToDelete == null)
                return RedirectToAction("List");

            return View(pageToDelete);
        }

        [POST("pages/delete/{id}")]
        public ActionResult Delete(int id, Boolean delete)
        {
            LayersCmsPage pageToDelete = _pageReads.GetById(id);

            // Return to the list page if the id is invalid
            if (pageToDelete != null && delete)
            {
                // Delete the page from the database
                _pageWrites.Delete(pageToDelete);
            }

            // Redirect back to the pages list
            return RedirectToAction("List");
        }

        [GET("pages/add")]
        public ActionResult Add(int? parentId = null)
        {
            String baseUrl = "/";
            if (parentId.HasValue)
            {
                LayersCmsPage parent = _pageReads.GetById(parentId.Value);
                if (parent != null)
                {
                    baseUrl = parent.Url;

                    // Insert a forward slash at the end of the url if one hasn't already been set
                    if (!baseUrl.EndsWith("/"))
                        baseUrl = baseUrl + "/";
                }
            }

            // Create the default model
            var model = new CmsPageModel()
                {
                    Active = true,
                    ParentId = parentId,
                    ShowInNavigation = true,
                    Url = baseUrl // Should always start with a forward slash
                };

            return View(model);
        }

        [POST("pages/add")]
        public ActionResult Add(CmsPageModel model)
        {
            if (ModelState.IsValid)
            {
                // Check that the url is unique
                if (_pageReads.GetByUrl(model.Url) != null)
                {
                    ModelState.AddModelError("Url", "This url is already in use. Please enter a different url");
                }
                

                // Check if any further validation errors have been applied
                if (ModelState.IsValid)
                {
                    // All validation passed
                    // Insert the new record
                    _pageWrites.Insert(new LayersCmsPage()
                        {
                            Active = model.Active,
                            Content = model.Content,
                            CustomScripts = model.CustomScripts,
                            DisplayName = model.DisplayName,
                            MetaDescription = model.MetaDescription,
                            MetaKeywords = model.MetaKeywords,
                            ParentId = model.ParentId,
                            PageTitle = model.PageTitle,
                            PublishEnd = MergeDateAndTime(model.PublishEndDate, model.PublishEndTime),
                            PublishStart = MergeDateAndTime(model.PublishStartDate, model.PublishStartTime),
                            RedirectTypeEnum = RedirectTypeEnum.None,
                            RedirectUrl = null,
                            ShowInNavigation = model.ShowInNavigation,
                            SortOrder = _pageReads.GetMaxSortOrderForParent(model.ParentId),
                            Url = model.Url,
                            WindowTitle = model.WindowTitle
                        });

                    // Redirect to the listing page
                    return RedirectToAction("List");
                }

            }

            // Validation failed, show the original view with errors
            return View();
        }

        [GET("pages/edit/{id}")]
        public ActionResult Edit(int id)
        {
            LayersCmsPage pageToEdit = _pageReads.GetById(id);

            // Return to the list page if the id is invalid
            if (pageToEdit == null)
                return RedirectToAction("List");

            // Create the view model from the database page
            var model = new CmsPageModel()
                {
                    Active = pageToEdit.Active,
                    Content = pageToEdit.Content,
                    CustomScripts = pageToEdit.CustomScripts,
                    DisplayName = pageToEdit.DisplayName,
                    Id = pageToEdit.Id,
                    MetaDescription = pageToEdit.MetaDescription,
                    MetaKeywords = pageToEdit.MetaKeywords,
                    PageTitle = pageToEdit.PageTitle,
                    ParentId = pageToEdit.ParentId,
                    PublishEndDate = pageToEdit.PublishEnd,
                    PublishEndTime = (pageToEdit.PublishEnd.HasValue ? pageToEdit.PublishEnd.Value.ToString("HH:mm") : null),
                    PublishStartDate = pageToEdit.PublishStart,
                    PublishStartTime = (pageToEdit.PublishStart.HasValue ? pageToEdit.PublishStart.Value.ToString("HH:mm") : null),
                    RedirectType = pageToEdit.RedirectType,
                    RedirectUrl = pageToEdit.RedirectUrl,
                    ShowInNavigation = pageToEdit.ShowInNavigation,
                    Url = pageToEdit.Url,
                    WindowTitle = pageToEdit.WindowTitle
                };

            return View(model);
        }

        [POST("pages/edit/{id}")]
        public ActionResult Edit(int id, CmsPageModel model)
        {
            if (ModelState.IsValid)
            {
                // Check that the url is unique
                LayersCmsPage pageWithSameUrl = _pageReads.GetByUrl(model.Url);
                if (pageWithSameUrl != null && pageWithSameUrl.Id != id)
                {
                    ModelState.AddModelError("Url", "This url is already in use. Please enter a different url");
                }


                // Check if any further validation errors have been applied
                if (ModelState.IsValid)
                {
                    // All validation passed
                    // Update the record
                    LayersCmsPage existingPage = _pageReads.GetById(id);

                    existingPage.Active = model.Active;
                    existingPage.Content = model.Content;
                    existingPage.CustomScripts = model.CustomScripts;
                    existingPage.DisplayName = model.DisplayName;
                    existingPage.MetaDescription = model.MetaDescription;
                    existingPage.MetaKeywords = model.MetaKeywords;
                    existingPage.ParentId = model.ParentId;
                    existingPage.PageTitle = model.PageTitle;
                    existingPage.PublishEnd = MergeDateAndTime(model.PublishEndDate, model.PublishEndTime);
                    existingPage.PublishStart = MergeDateAndTime(model.PublishStartDate, model.PublishStartTime);
                    existingPage.RedirectTypeEnum = RedirectTypeEnum.None; // Not yet implemented
                    existingPage.RedirectUrl = null; // Not yet implemented
                    existingPage.ShowInNavigation = model.ShowInNavigation;
                    existingPage.Url = model.Url;
                    existingPage.WindowTitle = model.WindowTitle;

                    _pageWrites.Update(existingPage);

                    // Redirect to the listing page
                    return RedirectToAction("List");
                }

            }

            // Validation failed, show the original view with errors
            return View(model);
        }


        #endregion

    }
}
