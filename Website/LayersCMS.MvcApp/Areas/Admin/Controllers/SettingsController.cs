using AttributeRouting.Web.Mvc;
using LayersCMS.Data.Domain.Core.Settings;
using LayersCMS.Data.Persistence.Interfaces.Reads;
using LayersCMS.Data.Persistence.Interfaces.Writes;
using LayersCMS.MvcApp.Areas.Admin.Models.Settings;
using System.Web.Mvc;
using LayersCMS.Web.Controllers;

namespace LayersCMS.MvcApp.Areas.Admin.Controllers
{
    public class SettingsController : LayersCmsAdminController
    {
        #region Constructor and Dependencies

        private readonly ILayersCmsSettingReads _settingReads;
        private readonly ILayersCmsSettingWrites _settingWrites;

        public SettingsController(ILayersCmsSettingReads settingReads,
                                    ILayersCmsSettingWrites settingWrites,
                                    ILayersCmsUserReads userReads)
                                    : base(userReads)
        {
            _settingReads = settingReads;
            _settingWrites = settingWrites;
        }

        #endregion

        [GET("settings")]
        public ActionResult Manage()
        {
            var model = new MainSettingsModel()
                {
                    ContactEmailAddress = _settingReads.GetStringValueForSettingType(LayersCmsSettingType.ContactEmailAddress),
                    ContactPhoneNumber = _settingReads.GetStringValueForSettingType(LayersCmsSettingType.ContactTelephoneNumber),
                    GoogleAnalyticsAccountId = _settingReads.GetStringValueForSettingType(LayersCmsSettingType.GoogleAnalyticsAccountId)
                };

            return View(model);
        }

        [POST("settings")]
        public ActionResult Manage(MainSettingsModel model)
        {
            if (ModelState.IsValid)
            {
                // Save every setting
                _settingWrites.InsertOrUpdateByType(LayersCmsSettingType.ContactEmailAddress, model.ContactEmailAddress);
                _settingWrites.InsertOrUpdateByType(LayersCmsSettingType.ContactTelephoneNumber, model.ContactPhoneNumber);
                _settingWrites.InsertOrUpdateByType(LayersCmsSettingType.GoogleAnalyticsAccountId, model.GoogleAnalyticsAccountId);

                // Set the saved successfully flag to display a success message
                model.SavedSuccessfully = true;
            }

            // Show the view again
            return View(model);
        }

    }
}
