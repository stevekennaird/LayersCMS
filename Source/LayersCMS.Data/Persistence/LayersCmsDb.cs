using ServiceStack.OrmLite;
using System;
using System.Configuration;
using System.Data;

namespace LayersCMS.Data.Persistence
{
    /// <summary>
    /// Should be the single point of reference for constructing connections to the database
    /// </summary>
    public class LayersCmsDb
    {
        private const String ConnectionStringKey = "LayersCms";
        internal OrmLiteConnectionFactory DbFactory;

        public LayersCmsDb()
        {
            // Get the connection string
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringKey];
            if (connectionString == null)
                throw new NullReferenceException("No connection string exists by that key.");

            // Initialise the data connection factory
            DbFactory = new OrmLiteConnectionFactory(connectionString.ConnectionString, false, SqlServerDialect.Provider);
        }

        /// <summary>
        /// Returns an open database connection, ready to use for reads/writes etc
        /// </summary>
        public virtual IDbConnection GetDbConnection()
        {
            return DbFactory.OpenDbConnection();
        }

    }
}
