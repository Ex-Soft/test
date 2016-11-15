/*
 * Created by: Malovic, Nikola
 * Created: 11/12/2007
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Pluggin
{
    public class Builder
    {
        public static IEnumerable<string> GetUsers()
        {
            AuthenticationConfigurationSection builderSection = GetAuthenticationConfigurationSection();
            foreach (UserConfigurationElement userConfigurationElement in builderSection.Users)
            {
                yield return
                    String.Format("id:{0}, name:{1}, surname:{2}", userConfigurationElement.Id,
                                  userConfigurationElement.FirstName, userConfigurationElement.LastName);
            }
        }

        /// <summary>
        /// Gets the config file URL.
        /// </summary>
        /// <returns></returns>
        private static AuthenticationConfigurationSection GetAuthenticationConfigurationSection()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            Assembly asm = Assembly.GetCallingAssembly();
            Uri uri = new Uri(Path.GetDirectoryName(asm.CodeBase));
            fileMap.ExeConfigFilename = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar + "pluggin.dll.config"; //Path.Combine(uri.LocalPath, "pluggin.dll.config");
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            AuthenticationConfigurationSection authConfigurationSection =
                config.GetSectionGroup("SomeSectionGroupName").Sections["AuthenticationSection"] as
                AuthenticationConfigurationSection;
            if (authConfigurationSection == null)
                throw new NotSupportedException();

            return authConfigurationSection;
        }
    }
}