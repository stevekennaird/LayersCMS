using System.Configuration;

namespace QuickWin.MvcApplication.Application.Config
{
    public class QuickWinConfigHelper
    {
        private readonly QuickWinConfigurationSection _configSection;

        public QuickWinConfigHelper()
        {
            _configSection = ConfigurationManager.GetSection("QuickWin") as QuickWinConfigurationSection;
        }

        public string GetTheme()
        {
            return _configSection.Theme;
        }

        public string GetCompanyName()
        {
            return _configSection.CompanyName;
        }

        public string GetContactPhone()
        {
            return _configSection.ContactPhone;
        }

        public string GetContactEmailAddress()
        {
            return _configSection.ContactEmail;
        }
    }
}