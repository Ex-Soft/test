using System.Configuration;

namespace TestConfig
{
    public sealed class MyConfigurationElementCollection : ConfigurationElementCollection
    {
        private readonly static ConfigurationPropertyCollection _properties;

        static MyConfigurationElementCollection()
        {
            _properties = new ConfigurationPropertyCollection();
        }


        public MyConfigurationElementCollection() : base()
        {
            AddElementName = "MyConfigurationElement";
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

        public new MyConfigurationElement this[string name]
        {
            get
            {
                return (MyConfigurationElement)this.BaseGet(name);
            }
        }

        public void Add(MyConfigurationElement knownGroup)
        {
            this.BaseAdd(knownGroup);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MyConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MyConfigurationElement)element).Name;
        }
    }
}
