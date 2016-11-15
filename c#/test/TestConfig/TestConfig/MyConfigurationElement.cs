using System.Configuration;

namespace TestConfig
{
    public sealed class MyConfigurationElement : ConfigurationElement
    {
        private static readonly ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _propName;

        static MyConfigurationElement()
        {
            _propName = new ConfigurationProperty("name", typeof(string), string.Empty, ConfigurationPropertyOptions.IsKey);
            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_propName);
        }

        internal MyConfigurationElement()
        {
        }

        public MyConfigurationElement(string name)
        {
            base[_propName] = name;
        }

        [ConfigurationProperty("name", IsKey = true, DefaultValue = "")]
        public string Name
        {
            get
            {
                return (string)this[_propName];
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
