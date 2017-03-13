using System.Configuration;

namespace TestConfig
{
    public class FileExtension : ConfigurationSection
    {
        public const string SectionName = "fileExtension";
        private const string ItemsCollectionName = "items";

        [ConfigurationProperty(ItemsCollectionName)]
        [ConfigurationCollection(typeof(ItemsCollection), AddItemName = "add")]
        public ItemsCollection Items { get { return (ItemsCollection)base[ItemsCollectionName]; } }
    }

    public class ItemsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ItemElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ItemElement)element).Value;
        }
    }

    public class ItemElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}
