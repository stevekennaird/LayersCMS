using System.Configuration;

namespace MvcApplication.Application.Helpers
{
    public class QuickWinThemeHelper
    {
        public string GetConfigTheme()
        {
            return ConfigurationManager.AppSettings["QuickWin:Theme"] ?? "standard";
        }
    }
}