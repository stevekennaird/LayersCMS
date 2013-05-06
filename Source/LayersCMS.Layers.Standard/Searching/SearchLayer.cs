using System;
using System.Data;
using System.Web.Mvc;
using System.Web.Routing;
using LayersCMS.Layers.Core.Base;

namespace LayersCMS.Layers.Standard.Searching
{
    public class SearchLayer : Layer
    {
        public override string Name
        {
            get { return "Search Results"; }
        }

        public override string PrimaryAdminUrl
        {
            get { return null; } // Don't show in the admin area nav
        }

        public override bool Enabled
        {
            get { return true; }
        }

        public override void InitialiseDatabase(IDbConnection dbConn)
        {
            // No need to initialise any tables for this layer
            return;
        }

        public override void InitialiseLayerForApplication(RouteCollection routes)
        {
            routes.MapRoute(
                "LayersCmsBasicSearchResults", // Route name
                "search/{query}", // URL with parameters
                new { controller = "Search", action = "BasicSearchResults", query = UrlParameter.Optional }, // Parameter defaults
                new [] {typeof(SearchController).Namespace}
            );
        }
    }
}
