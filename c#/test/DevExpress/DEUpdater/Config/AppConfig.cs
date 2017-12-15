using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using static System.Console;

namespace DEUpdater.Config
{
    public class Pattern
    {
        public Regex Expression { get; }
        public bool IsMajorVersion { get; }

        public Pattern(Pattern obj) : this(obj.Expression, obj.IsMajorVersion)
        {}

        public Pattern(Regex expression = null, bool isMajorVersion = false)
        {
            Expression = expression;
            IsMajorVersion = isMajorVersion;
        }
    }

    public class AppConfig
    {
        public readonly Regex
            FullVersionPattern = new Regex("\\d+\\.\\d+\\.\\d+\\.\\d+"),
            MajoirVersionPattern = new Regex("\\d+\\.\\d+(?=\\.)"),
            IsMajorVersionPattern = new Regex("(?<=\\))\\\\d\\+\\\\\\.\\\\d\\+(?=\\()");

        private string
            _sourceDirectory,
            _fullVersion;

        public string[] FileExtensions { get; private set; }

        public Pattern[] Patterns { get; private set; }

        public string SourceDirectory
        {
            get { return _sourceDirectory; }
            set { _sourceDirectory = PatchDirectory(value); }
        }

        public string FullVersion
        {
            get { return _fullVersion; }
            set
            {
                if (!FullVersionPattern.IsMatch(value))
                    return;

                var match = MajoirVersionPattern.Match(value);
                if (!match.Success)
                    return;

                MajorVersion = match.Value;
                _fullVersion = value;
            }
        }

        public string MajorVersion { get; private set; }

        public void Load()
        {
            FileExtensions = Load("fileExtension");
            Patterns = Load("pattern").Select(CreatePattern).Where(item => item != null).ToArray();
        }

        private static string[] Load(string sectionName)
        {
            DEUpdaterConfigurationSection configurationSection;
            return (configurationSection = ConfigurationManager.GetSection(sectionName) as DEUpdaterConfigurationSection) != null ? configurationSection.Items.OfType<ItemElement>().Select(item => item.Value).ToArray() : new string[0];
        }

        private static string PatchDirectory(string directory)
        {
            return !string.IsNullOrWhiteSpace(directory) ? (!directory.EndsWith(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture)) ? directory + Path.DirectorySeparatorChar : directory) : directory;
        }

        private Pattern CreatePattern(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return null;

            Regex regex;

            try
            {
                regex = new Regex(expression);
            }
            catch (Exception e)
            {
                regex = null;
                WriteLine("\"{0}\": {1}", expression, e.Message);
            }

            return regex != null ? new Pattern(regex, IsMajorVersionPattern.IsMatch(expression)) : null;
        }
    }
}
