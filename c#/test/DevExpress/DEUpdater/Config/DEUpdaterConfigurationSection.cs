using System.Configuration;

namespace DEUpdater.Config
{
    public class DEUpdaterConfigurationSection : ConfigurationSection
    {
        private const string ItemsCollectionName = "items";

        [ConfigurationProperty(ItemsCollectionName)]
        [ConfigurationCollection(typeof (ItemsCollection), AddItemName = "add")]
        public ItemsCollection Items
        {
            get { return (ItemsCollection)base[ItemsCollectionName]; }
            set { base[ItemsCollectionName] = value; }
        }
    }

    [ConfigurationCollection(typeof(ItemElement))]
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
        [ConfigurationProperty("value", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }
    }
}
