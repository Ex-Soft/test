/*
 * Created by: Malovic, Nikola
 * Created: 11/12/2007
 */
using System.Configuration;

namespace Pluggin
{
    public class UserConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsKey = true, IsRequired = true)]
        public string Id
        {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string FirstName
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("surname", IsRequired = false)]
        public string LastName
        {
            get { return (string)this["surname"]; }
            set { this["surname"] = value; }
        }
    }
}