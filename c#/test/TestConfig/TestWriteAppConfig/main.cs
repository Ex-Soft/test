using System.Linq;
using System.Configuration;

namespace TestAppConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string
                key = "keyAAA",
                keyValue = "keyAAAValue";

            if (config.AppSettings.Settings.AllKeys.Contains(key))
                config.AppSettings.Settings[key].Value = keyValue;
            else
                config.AppSettings.Settings.Add(key, keyValue);

            key = "keyBBB";
            keyValue = "keyBBBValue";
            if (config.AppSettings.Settings.AllKeys.Contains(key))
                config.AppSettings.Settings[key].Value = keyValue;
            else
                config.AppSettings.Settings.Add(key, keyValue);

            config.AppSettings.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
