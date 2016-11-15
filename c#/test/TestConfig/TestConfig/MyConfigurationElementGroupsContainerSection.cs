using System.Configuration;

namespace TestConfig
{
    public sealed class MyConfigurationElementGroupsContainerSection : ConfigurationSection
    {
        public const string SectionName = ConfigurationMetaData.SubSectionRoot + "/MyConfigurationElementGroupsContainer";
        private const string KnownGroupsKey = "MyConfigurationElementGroups";

        private static readonly ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _knownGroupsProperty;

        static MyConfigurationElementGroupsContainerSection()
        {
            _knownGroupsProperty = new ConfigurationProperty(KnownGroupsKey, typeof(MyConfigurationElementCollection), new MyConfigurationElementCollection(), ConfigurationPropertyOptions.None);

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_knownGroupsProperty);
        }


        [ConfigurationProperty(KnownGroupsKey)]
        public MyConfigurationElementCollection KnownGroups
        {
            get
            {
                return (MyConfigurationElementCollection)base[_knownGroupsProperty];
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
