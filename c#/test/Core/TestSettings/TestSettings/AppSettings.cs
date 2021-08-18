using System;
using System.Collections.Generic;

namespace TestSettings
{
    public class AppSettings
    {
        public string DbConnectionName { get; set; }
        public string Victim { get; set; }
        public string Common1 { get; set; }
        public string Common2 { get; set; }
        public string Common3 { get; set; }
    }

    public class Excludes
    {
        public List<string> Exclude { get; set; } = new();
    }

    public class TestType
    {
        public Type Type { get; set; }
    }
}
