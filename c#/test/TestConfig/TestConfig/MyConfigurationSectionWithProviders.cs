using System.Configuration;

namespace TestConfig
{
    public sealed class MyConfigurationSectionWithProviders : ConfigurationSection
    {
        public const string SectionName = ConfigurationMetaData.SubSectionRoot + "/MyConfigurationSectionWithProviders";
        private const string ProvidersKey = "providers";

        private static readonly ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _propProviders;

        static MyConfigurationSectionWithProviders()
        {
            _propProviders = new ConfigurationProperty(ProvidersKey, typeof(ProviderSettingsCollection), null, ConfigurationPropertyOptions.None);

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_propProviders);
        }

        [ConfigurationProperty(ProvidersKey)]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)base[_propProviders];
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }
    }
}
