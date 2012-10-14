using System.Configuration;

namespace LayersCMS.MvcApp.Application.Config
{
    public class LayersCmsConfigHelper
    {
        private readonly LayersCmsConfigurationSection _configSection;

        public LayersCmsConfigHelper()
        {
            _configSection = ConfigurationManager.GetSection("LayersCMS") as LayersCmsConfigurationSection;
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