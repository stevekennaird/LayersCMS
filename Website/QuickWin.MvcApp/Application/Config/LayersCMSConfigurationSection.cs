using System.Configuration;

namespace LayersCMS.MvcApp.Application.Config
{
    public class LayersCmsConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("theme", DefaultValue = "standard", IsRequired = true)]
        public string Theme
        {
            get { return (string)this["theme"]; }
            set { this["theme"] = value; }
        }

        [ConfigurationProperty("companyName", DefaultValue = "Acme Parts Co", IsRequired = true)]
        public string CompanyName
        {
            get { return (string)this["companyName"]; }
            set { this["companyName"] = value; }
        }

        [ConfigurationProperty("contactPhone", DefaultValue = "01622 000 000", IsRequired = true)]
        public string ContactPhone
        {
            get { return (string)this["contactPhone"]; }
            set { this["contactPhone"] = value; }
        }

        [ConfigurationProperty("contactEmail", DefaultValue = "test@test.com", IsRequired = true)]
        public string ContactEmail
        {
            get { return (string)this["contactEmail"]; }
            set { this["contactEmail"] = value; }
        }
    }
}