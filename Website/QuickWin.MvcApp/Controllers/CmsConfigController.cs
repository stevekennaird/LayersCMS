using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using QuickWin.MvcApp.Models.CmsConfig;

namespace QuickWin.MvcApp.Controllers
{
    public class CmsConfigController : Controller
    {
        [GET("cms-config/initial-setup")]
        public ActionResult SetupDatabase()
        {
            // Initialise the model, load any drop downs
            var model = new SetupDatabaseModel();
            InitialiseSetupDatabaseModel(model);

            // Need to capture all fields required for new DatabaseSchemaSetup(..).Initialise(.., ..)

            // Include a ReCaptcha on this page to prevent attack attempts??
            return View(model);
        }

        [POST("cms-config/initial-setup")]
        public ActionResult SetupDatabase(SetupDatabaseModel model) // The model should obviously be a proper class
        {
            if (ModelState.IsValid)
            {
                // Check the key entered equals AppSettings[""],
                // if so, run new DatabaseSchemaSetup(..).Initialise(.., ..);
                // Then redirect to SetupDatabaseComplete action
            }

            InitialiseSetupDatabaseModel(model);
            return View(model);
        }

        [GET("cms-config/initial-setup/complete")]
        public ActionResult SetupDatabaseComplete(bool success, string error = null)
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
