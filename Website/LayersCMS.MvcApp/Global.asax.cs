using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using LayersCMS.MvcApp.App_Start;
using LayersCMS.Web.ViewEngines;

namespace LayersCMS.MvcApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetupViewEngines();
        }

        private void SetupViewEngines()
        {
            // Clear the aspx view engine for efficiency: http://blogs.msdn.com/b/marcinon/archive/2011/08/16/optimizing-mvc-view-lookup-performance.aspx
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new LayersCmsViewEngine());
        }
    }
}