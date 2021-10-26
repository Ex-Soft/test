using System.Collections.Generic;

namespace TestSettings
{
    public class AppSettings
    {
        public string DbConnectionName { get; set; }
        public string Victim { get; set; }
    }

    public class Excludes
    {
        public List<string> Exclude { get; set; } = new();
    }
}
