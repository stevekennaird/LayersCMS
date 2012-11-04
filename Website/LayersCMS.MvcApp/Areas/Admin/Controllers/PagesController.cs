using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Data.Persistence.Interfaces.Writes.Base;
using LayersCMS.MvcApp.Areas.Admin.Controllers.Base;
using LayersCMS.MvcApp.Areas.Admin.Models.Auth;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class PagesController : LayersCmsAdminController
    {
        #region Constructor and Dependencies
        private readonly ILayersCmsPageReads _pageReads;
        private readonly ILayersCmsPageWrites _pageWrites;

        public PagesController(ILayersCmsPageReads pageReads, 
                                ILayersCmsPageWrites pageWrites)
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
                            CustomScripts = null,
                            MetaDescription = model.MetaDescription,
                            MetaKeywords = model.MetaKeywords,
                            ParentId = model.ParentId,
                            PageTitle = model.PageTitle,
                            PublishEnd = MergeDateAndTime(model.PublishEndDate, model.PublishEndTime),
                            PublishStart = MergeDateAndTime(model.PublishStartDate, model.PublishStartTime),
                            RedirectTypeEnum = RedirectTypeEnum.None,
                            RedirectUrl = null,
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

        #endregion

        #region Private Methods

        /// <summary>
        /// Takes a date field and a time string (e.g. 04:52:00) and merges them together to a valid DateTime value
        /// </summary>
        /// <param name="date">A nullable DateTime value to take the date part from</param>
        /// <param name="time">A time string (e.g. 04:52:00)</param>
        private DateTime? MergeDateAndTime(DateTime? date, String time)
        {
            if (date.HasValue)
            {
                if (!String.IsNullOrWhiteSpace(time) && time.Contains(":"))
                {
                    try
                    {
                        IEnumerable<int> timeParts = time.Split(':').Select(int.Parse).ToArray();
                        date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day,
                                            timeParts.ElementAtOrDefault(0),
                                            timeParts.ElementAtOrDefault(1),
                                            timeParts.ElementAtOrDefault(2));
                    }
                    catch (Exception)
                    {
                        return date;
                    }
                }
                return date;
            }
            return null;
        }

        #endregion

    }
}
