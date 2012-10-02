using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using AttributeRouting.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(MvcApplication.App_Start.QuickWinRouting), "Start")]

namespace MvcApplication.App_Start
{
    public static class QuickWinRouting
    {
        public static void RegisterAttributeRoutes(RouteCollection routes)
        {
            // See http://github.com/mccalltd/AttributeRouting/wiki for more options.
            // To debug routes locally using the built in ASP.NET development server, go to /routes.axd

            routes.MapAttributeRoutes(config =>
            {
                config.ScanAssembly(Assembly.GetExecutingAssembly());
                config.UseLowercaseRoutes = true;
            });
        }

        public static void RegisterCmsRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "QuickWinCmsPage", // Route name
                "{url}", // URL with parameters
                new { controller = "QuickWinCmsPage", action = "HandleUrl" } // Parameter defaults
            );
        }

        public static void Start()
        {
            RegisterAttributeRoutes(RouteTable.Routes);

            // Only add the routes for the CMS if the CMS has been activated
            string useCmsAppSetting = ConfigurationManager.AppSettings["UseCms"] ?? "";
            if (useCmsAppSetting.ToLower() == "true")
                RegisterCmsRoutes(RouteTable.Routes);
        }
    }
}
