using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using QuickWin.Cms.Data.Persistence.Setup;
using QuickWin.Cms.Util.Security.Interfaces;
using QuickWin.MvcApp.Models.CmsConfig;
using ServiceStack.OrmLite.SqlServer;

namespace QuickWin.MvcApp.Controllers
{
    public class CmsConfigController : BaseController
    {
        private readonly IHashHelper _hashHelper;

        #region Constructor and Dependencies

        public CmsConfigController(IHashHelper hashHelper)
        {
            _hashHelper = hashHelper;
        }

        #endregion
        

        [GET("cms-config/initial-setup")]
        public ActionResult SetupDatabase()
        {
            // Initialise the model, load any drop downs
            var model = new SetupDatabaseModel();
            InitialiseSetupDatabaseModel(model);

            return View(model);
        }

        [POST("cms-config/initial-setup")]
        public ActionResult SetupDatabase(SetupDatabaseModel model) // The model should obviously be a proper class
        {
            String setupSecretKey = ConfigurationHelper.GetApplicationSettingAsType<String>("QuickWin:CmsDatabaseSetupSecretKey");

            if (ModelState.IsValid)
            {
                if (model.CmsDatabaseSetupSecretKey == setupSecretKey)
                {
                    // Initialise the database
                    try
                    {
                        new DatabaseSchemaSetup(_hashHelper).Initialise(new DatabaseSetupConfig()
                        {
                            DatabaseDialect = new SqlServerOrmLiteDialectProvider(),
                            UserEmailAddress = model.UserEmailAddress,
                            UserPassword = model.UserPassword,
                            ConnectionStringName = model.ConnectionStringName
                        });

                        // Initialisation complete. Show success message
                        return RedirectToAction("SetupDatabaseComplete");
                    }
                    catch (Exception e)
                    {
                        // Error initialising database. Show exception message
                        ModelState.AddModelError(String.Empty, "Unable to initialise database. Error: " + e.Message);
                    }

                }
                else
                {
                    // Setup secret key incorrect,
                    ModelState.AddModelError("CmsDatabaseSetupSecretKey", "Incorrect");
                }
            }

            // Populate the model ready for display
            InitialiseSetupDatabaseModel(model);


            return View(model);
        }

        [GET("cms-config/initial-setup/complete")]
        public ActionResult SetupDatabaseComplete()
        {
            return View();
        }


        #region Private Methods

        private void InitialiseSetupDatabaseModel(SetupDatabaseModel model)
        {
            // Get the count of connection string
            int connStrCount = ConfigurationManager.ConnectionStrings.Count;
            
            // If no connection strings are found, throw an exception
            if (connStrCount == 0)
                throw new Exception("There must be at least one connection string specified in the web.config file");

            // Initialise a new list and add an item for each connection string found
            var connStrings = new List<SelectListItem>();
            connStrings.Add(new SelectListItem(){Text = "--- select ---"});

            for (int i = 0; i < connStrCount; i++)
            {
                String connStr = ConfigurationManager.ConnectionStrings[i].Name;
                connStrings.Add(new SelectListItem() {Text = connStr, Value = connStr});
            }

            // Set the value on the model
            model.ConnectionStringOptions = connStrings;
        }

        #endregion

    }
}
