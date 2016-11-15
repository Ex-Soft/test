/*
 * Created by: Malovic, Nikola
 * Created: 11/06/2007
 */
using System.Configuration;

namespace Pluggin
{
    public class AuthenticationConfigurationSection : ConfigurationSection
    {

        [ConfigurationProperty("UserCollection", IsDefaultCollection = true)]
        public UserConfigurationElementCollection Users
        {
            get { return (UserConfigurationElementCollection)base["UserCollection"]; }
        }

    }
}