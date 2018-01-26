// http://www.codeproject.com/Articles/16466/Unraveling-the-Mysteries-of-NET-Configuration
// http://www.codeproject.com/Articles/16724/Decoding-the-Mysteries-of-NET-Configuration
// http://www.codeproject.com/Articles/19675/Cracking-the-Mysteries-of-NET-Configuration
// https://msdn.microsoft.com/en-us/library/2tw134k3.aspx
// http://blog.danskingdom.com/adding-and-accessing-custom-sections-in-your-c-app-config/

using System;
using System.Configuration;
using System.Linq;

namespace TestConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            FileExtension fileExtensionsSection;
            if ((fileExtensionsSection = ConfigurationManager.GetSection(FileExtension.SectionName) as FileExtension) != null)
            {
                foreach (ItemElement item in fileExtensionsSection.Items)
                    Console.WriteLine("{{value=\"{0}\"}}", item.Value);
            }
            
            var querySection = ConfigurationManager.GetSection(QuerySection.SectionName) as QuerySection;

            if (querySection != null)
            {
                Console.WriteLine("statement=\"{0}\", attributeBool=\"{1}\"", querySection.Query.Statement, querySection.Query.AttributeBool);

                foreach (ClauseElement clause in querySection.Clauses)
                    Console.WriteLine($"{{ name=\"{clause.Name}\", condition=\"{clause.Condition}\", type=\"{clause.Type}\", operator=\"{clause.Operator}\", boolRequired={clause.BoolRequired}, BoolOptionalTrue={clause.BoolOptionalTrue}, BoolOptionalFalse={clause.BoolOptionalFalse}}}");

                ClauseElement
                    clauseName1 = querySection.Clauses.OfType<ClauseElement>().FirstOrDefault(item => item.Name == "name1")/*,
                    clauseName2 = querySection.Clauses.Item["Name2"]*/;

            }

            const string
                connectionStringKey = "chicago";

            string
                connectionString = string.Empty;

            if (ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Any(cs => cs.Name == connectionStringKey))
                connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
            Console.WriteLine(connectionString);

            MyConfigurationSection
                siteWebSection=(MyConfigurationSection)System.Configuration.ConfigurationManager.GetSection(MyConfigurationSection.SectionName);

            Console.WriteLine(siteWebSection.Url);

            MyConfigurationElementGroupsContainerSection
                unityContainerSection = (MyConfigurationElementGroupsContainerSection)System.Configuration.ConfigurationManager.GetSection(MyConfigurationElementGroupsContainerSection.SectionName);

            MyConfigurationElementCollection
                unityContainerKnownGroupElementCollection = unityContainerSection.KnownGroups;

            foreach (MyConfigurationElement e in unityContainerKnownGroupElementCollection)
                Console.WriteLine(e.Name);

            MyConfigurationSectionWithProviders
                extensionSection =(MyConfigurationSectionWithProviders)System.Configuration.ConfigurationManager.GetSection(MyConfigurationSectionWithProviders.SectionName);

            ProviderSettingsCollection
                providerSettingsCollection = extensionSection.Providers;

            foreach(ProviderSettings ps in providerSettingsCollection)
                Console.WriteLine(ps.Name);

            Console.ReadLine();
        }
    }
}
