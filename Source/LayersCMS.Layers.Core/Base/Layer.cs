using System.Data;
using System.Web.Routing;

namespace LayersCMS.Layers.Core.Base
{
    /// <summary>
    /// A Layer is essentially a module, e.g. a blog module, or a jobs module
    /// </summary>
    public abstract class Layer
    {
        public abstract string Name { get; }

        /// <summary>
        /// The url to link to in the admin area navigation.
        /// If null, the layer won't appear in the navigation in the admin area.
        /// </summary>
        public abstract string PrimaryAdminUrl { get; }

        public abstract bool Enabled { get; }

        /// <summary>
        /// Any database table creation that needs to happen for this module.
        /// Should only need to happen once.
        /// </summary>
        /// <param name="dbConn">A connection to the database</param>
        public abstract void InitialiseDatabase(IDbConnection dbConn);

        /// <summary>
        /// The initialisation code to run on Application Start
        /// </summary>
        public abstract void InitialiseLayerForApplication(RouteCollection routes);
    }
}
