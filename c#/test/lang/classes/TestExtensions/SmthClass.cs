namespace TestExtensions
{
    public class SmthClass
    {
        private string PrivateString { get; set; }
        protected string ProtectedString { get; set; }
        public string PublicString { get; set; }
    }

    public static class SmthClassExtension
    {
        public static void TestNull(this SmthClass smthClass)
        {
            System.Diagnostics.Debug.WriteLine("It Works!!! Ж8-/");
        }

        //public static string GetPrivateString(this SmthClass smthClass)
        //{
        //    return smthClass.PrivateString; // Error CS0122  'SmthClass.PrivateString' is inaccessible due to its protection level
        //}

        public static string GetPublicString(this SmthClass smthClass)
        {
            return smthClass.PublicString;
        }
    }
}
