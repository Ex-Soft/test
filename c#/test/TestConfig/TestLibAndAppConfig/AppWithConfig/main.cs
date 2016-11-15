namespace AppWithConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var libWithConfigClass = new LibWithConfig.LibWithConfigClass();
            var value = libWithConfigClass.GetAppSettingValue("keyFromLib");
            System.Diagnostics.Debug.WriteLine(!string.IsNullOrWhiteSpace(value) ? value : "null");
            value = libWithConfigClass.GetAppSettingValue("keyFromApp");
            System.Diagnostics.Debug.WriteLine(!string.IsNullOrWhiteSpace(value) ? value : "null");
        }
    }
}
