using QuickWin.Cms.Data.Domain.Pages;
using QuickWin.Cms.Data.Domain.Security;
using QuickWin.Cms.Util.Security.Interfaces;
using ServiceStack.OrmLite;
using System;
using System.Data;

namespace QuickWin.Cms.Data.Persistence.Setup
{
    /// <summary>
    /// Constructs the database schema. Should only be run once, and access to run the code should be protected in the UI somehow,
    /// as this will drop and recreate all tables.
    /// </summary>
    public class DatabaseSchemaSetup
    {
        private readonly IHashHelper _hashHelper;
        private readonly OrmLiteConnectionFactory _dbFactory;

        public DatabaseSchemaSetup(String connectionString, IHashHelper hashHelper)
        {
            _hashHelper = hashHelper;
            // Initialise the data connection factory
            _dbFactory = new OrmLiteConnectionFactory(connectionString, false, SqlServerDialect.Provider);
        }

        /// <summary>
        /// Drops all tables matching the name of the QuickWinDomainObjects to be created,
        /// then creates fresh tables for those domain objects.
        /// </summary>
        public void Initialise(DatabaseSetupConfig config)
        {
            // Check the config class passed is valid, and we have all we need to complete the setup
            if (String.IsNullOrWhiteSpace(config.UserEmailAddress))
                throw new NullReferenceException("No UserEmailAddress specified. Cannot create primary user without an email address.");

            if (String.IsNullOrWhiteSpace(config.UserPassword))
                throw new NullReferenceException("No UserPassword specified. Cannot create primary user without a password.");

            
            // Open a database connection
            using (IDbConnection dbConn = _dbFactory.OpenDbConnection())
            {
                // Create the QuickWinPage table
                dbConn.DropAndCreateTable<QuickWinPage>();

                // Create the QuickWinUser table and insert the first user
                dbConn.DropAndCreateTable<QuickWinUser>();
                dbConn.Save(new QuickWinUser()
                    {
                        Active = true,
                        EmailAddress = config.UserEmailAddress,
                        Password = _hashHelper.HashString(config.UserPassword) // A hashed version of the plain text password
                    });

            }            
        }
    }
}
