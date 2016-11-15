using System.Configuration;

namespace TestConfig
{
    public sealed class MyConfigurationSection : ConfigurationSection
    {
        public const string SectionName = ConfigurationMetaData.SubSectionRoot + "/MyConfigurationSection";
        private const string UrlKey = "url";

        private static readonly ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _urlProperty;

        static MyConfigurationSection()
        {
            _urlProperty = new ConfigurationProperty(UrlKey, typeof(string), null, ConfigurationPropertyOptions.IsRequired);

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_urlProperty);
        }

        [ConfigurationProperty(UrlKey)]
        public string Url
        {
            get
            {
                return (string)base[_urlProperty];
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
