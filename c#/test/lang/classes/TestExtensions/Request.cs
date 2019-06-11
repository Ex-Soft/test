namespace TestExtensions
{
    public class Request
    {
        public string PreferredLanguage { get; set; }

        public Request(string preferredLanguage = "")
        {
            PreferredLanguage = preferredLanguage;
        }

        public Request(Request obj) : this(obj.PreferredLanguage)
        {}
    }
}
