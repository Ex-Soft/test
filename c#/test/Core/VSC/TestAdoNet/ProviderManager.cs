using System.Data.Common;

namespace TestAdoNet
{
    public class ProviderManager
    {
        public string ProviderName { get; set; }

        public DbProviderFactory Factory
        {
            get
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
                return factory;
            }
        }

        public ProviderManager()
        {
            ProviderName = ConfigurationSettings.GetProviderName(ConfigurationSettings.DbConnectionName);
        }

        public ProviderManager(string providerName)
        {
            ProviderName = providerName;
        }
    }
}
