/*
 * Created by: Malovic, Nikola
 * Created: 11/12/2007
 */
using System.Configuration;

namespace Pluggin
{
    public class UserConfigurationElementCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new UserConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UserConfigurationElement)element).Id;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "UserConfigurationElement"; }
        }
    }
}