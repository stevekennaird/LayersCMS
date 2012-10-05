using System;
using System.Configuration;

namespace QuickWin.MvcApp.Application.Config
{
    public class ApplicationConfigurationHelper
    {
        public T GetApplicationSettingAsType<T>(String appSettingKey)
        {
            String setting = ConfigurationManager.AppSettings[appSettingKey];
            if (!String.IsNullOrWhiteSpace(setting))
            {
                try
                {
                    return (T)Convert.ChangeType(setting, typeof(T));
                }
                catch {}
            }
            return default(T);
        }

        public String GetConnectionString(String connStrName)
        {
            ConnectionStringSettings connStr = ConfigurationManager.ConnectionStrings[connStrName];
            return connStr == null ? null : connStr.ConnectionString;
        }
    }
}