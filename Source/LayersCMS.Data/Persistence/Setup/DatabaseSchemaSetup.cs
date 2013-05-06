using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using LayersCMS.Data.Domain.Core.Pages;
using LayersCMS.Data.Domain.Core.Security;
using LayersCMS.Data.Domain.Core.Settings;
using LayersCMS.Layers.Core.Base;
using LayersCMS.Util.Security.Interfaces;
using ServiceStack.OrmLite;

namespace LayersCMS.Data.Persistence.Setup
{
    /// <summary>
    /// Constructs the database schema. Should only be run once, and access to run the code should be protected in the UI somehow,
    /// as this will drop and recreate all tables.
    /// </summary>
    public class DatabaseSchemaSetup
    {
        private readonly IHashHelper _hashHelper;

        /// <param name="hashHelper">The hashing helper to hash the user's password</param>
        public DatabaseSchemaSetup(IHashHelper hashHelper)
        {
            _hashHelper = hashHelper;
        }

        /// <summary>
        /// Initialise the database for both the core tables and any bespoke layers (modules)
        /// </summary>
        public void InitialiseDatabaseTables(DatabaseSetupConfig config)
        {
            // Get the connection string
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings[config.ConnectionStringName];
            if (connectionString == null)
                throw new NullReferenceException("No connection string exists by that key.");

            // Tell the configuration to use unicode, e.g. nvarchar compared to varchar in SQL Server
            config.DatabaseDialect.UseUnicode = true;

            // Initialise the data connection factory
            var dbFactory = new OrmLiteConnectionFactory(connectionString.ConnectionString, false, config.DatabaseDialect);

            // Check the config class passed is valid, and we have all we need to complete the setup
            if (config.DatabaseDialect == null)
                throw new NullReferenceException("No DatabaseDialect specified. Cannot initialise a database without knowing what type of database to use.");

            InitialiseCoreTables(config, dbFactory);

            InitialiseLayers(dbFactory);
        }

        /// <summary>
        /// Drops all tables matching the name of the LayersCmsDomainObjects to be created,
        /// then creates fresh tables for those domain objects.
        /// </summary>
        private void InitialiseCoreTables(DatabaseSetupConfig config, OrmLiteConnectionFactory dbFactory)
        {
            if (String.IsNullOrWhiteSpace(config.UserEmailAddress))
                throw new NullReferenceException("No UserEmailAddress specified. Cannot create primary user without an email address.");

            if (String.IsNullOrWhiteSpace(config.UserPassword))
                throw new NullReferenceException("No UserPassword specified. Cannot create primary user without a password.");

            
            // Open a database connection
            using (IDbConnection dbConn = dbFactory.OpenDbConnection())
            {
                // Create the LayersCmsPage table
                dbConn.DropAndCreateTable<LayersCmsPage>();

                // Add the homepage
                dbConn.Save(new LayersCmsPage()
                    {
                        Active = true,
                        Content = "<p>Welcome to Layers CMS</p>",
                        DisplayName = "Home",
                        PageTitle = "Index",
                        ParentId = null,
                        PublishEnd = null,
                        PublishStart = DateTime.Now.Date,
                        RedirectTypeEnum = RedirectTypeEnum.None,
                        RedirectUrl = null,
                        ShowInNavigation = true,
                        SortOrder = 0,
                        Url = "/",
                        WindowTitle = "Index"
                    });

                // Create the LayersCmsUser table and insert the first user
                dbConn.DropAndCreateTable<LayersCmsUser>();
                dbConn.Save(new LayersCmsUser()
                    {
                        Active = true,
                        EmailAddress = config.UserEmailAddress,
                        Password = _hashHelper.HashString(config.UserPassword) // A hashed version of the plain text password
                    });

                // Create the settings table and add some default settings
                dbConn.DropAndCreateTable<LayersCmsSetting>();
                dbConn.SaveAll(new []
                    {
                        new LayersCmsSetting(){SettingType = LayersCmsSettingType.ContactEmailAddress, Value = "email@address.com"},
                        new LayersCmsSetting(){SettingType = LayersCmsSettingType.ContactTelephoneNumber, Value = "0000 000000"},
                        new LayersCmsSetting(){SettingType = LayersCmsSettingType.GoogleAnalyticsAccountId, Value = ""}
                    });

            }            
        }

        /// <summary>
        /// Create any database tables for any layers (e.g. a news layer/module)
        /// </summary>
        private void InitialiseLayers(OrmLiteConnectionFactory dbFactory)
        {
            // Get a collection of layers using reflection
            IEnumerable<Layer> enabledLayers = new LayersHelper().GetEnabledLayers().ToList();

            if (!enabledLayers.Any())
            {
                // If there aren't any enabled layers, exit the method
                return;
            }
            
            // Open a database connection, then initialise the database
            // for each layer
            using (IDbConnection dbConn = dbFactory.OpenDbConnection())
            {
                using (IDbTransaction dbTran = dbConn.OpenTransaction())
                {
                    try
                    {
                        foreach (Layer enabledLayer in enabledLayers)
                        {
                            enabledLayer.InitialiseDatabase(dbConn);
                        }

                        // If no exceptions, commit the transaction
                        dbTran.Commit();
                    }
                    catch (Exception e)
                    {
                        // Exception caught, rollback the transaction
                        dbTran.Rollback();
                        throw e;
                    }
                }
            }
            
        }

        
    }
}
