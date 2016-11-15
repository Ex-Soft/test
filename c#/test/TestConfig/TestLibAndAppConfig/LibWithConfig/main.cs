using System.Configuration;

namespace LibWithConfig
{
    public class LibWithConfigClass
    {
        public string GetAppSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
