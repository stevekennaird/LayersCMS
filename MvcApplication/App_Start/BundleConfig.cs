using System.Web.Optimization;
using QuickWin.MvcApplication.Application.Config;
using QuickWin.MvcApplication.Application.Helpers;

namespace QuickWin.MvcApplication.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.unobtrusive*",
                        "~/scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/content/css").Include("~/content/bootstrap/css/bootstrap.css", "~/content/site.css", GetThemeCssFilepath()));

            bundles.Add(new StyleBundle("~/content/jquery-themes/base/css").Include(
                        "~/content/jquery-themes/base/jquery.ui.core.css",
                        "~/content/jquery-themes/base/jquery.ui.resizable.css",
                        "~/content/jquery-themes/base/jquery.ui.selectable.css",
                        "~/content/jquery-themes/base/jquery.ui.accordion.css",
                        "~/content/jquery-themes/base/jquery.ui.autocomplete.css",
                        "~/content/jquery-themes/base/jquery.ui.button.css",
                        "~/content/jquery-themes/base/jquery.ui.dialog.css",
                        "~/content/jquery-themes/base/jquery.ui.slider.css",
                        "~/content/jquery-themes/base/jquery.ui.tabs.css",
                        "~/content/jquery-themes/base/jquery.ui.datepicker.css",
                        "~/content/jquery-themes/base/jquery.ui.progressbar.css",
                        "~/content/jquery-themes/base/jquery.ui.theme.css"));
        }

        private static string GetThemeCssFilepath()
        {
            string themeName = new QuickWinConfigHelper().GetTheme();
            return string.Format("~/content/themes/{0}.css", themeName);
        }
    }
}