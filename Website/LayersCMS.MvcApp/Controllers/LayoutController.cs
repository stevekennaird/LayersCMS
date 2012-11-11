using LayersCMS.Data.Domain.Core.Settings;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.MvcApp.Controllers.Base;
using System;
using System.Web.Mvc;

namespace LayersCMS.MvcApp.Controllers
{
    public class LayoutController : BaseController
    {
        #region Constructor and Dependencies

        private readonly ILayersCmsSettingReads _settingReads;

        public LayoutController(ILayersCmsSettingReads settingReads)
        {
            _settingReads = settingReads;
        }

        #endregion


        [ChildActionOnly]
        public ActionResult GoogleAnalyticsTrackingCode()
        {
            // Get the GA account id from the settings table
            String accountId = _settingReads.GetStringValueForSettingType(LayersCmsSettingType.GoogleAnalyticsAccountId);

            if (!String.IsNullOrWhiteSpace(accountId))
            {
                // If a setting is found, render the view containing the script
                ViewBag.AccountCode = accountId;
                return PartialView();                
            }

            // No account id found, don't render the GA script
            return null;
        }

    }
}
