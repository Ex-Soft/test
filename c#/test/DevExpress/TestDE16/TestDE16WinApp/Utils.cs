using System.Configuration;
using System.Linq;

namespace TestDE16WinApp
{
    public static class Utils
    {
        public static string GetConnectionString(string connectionStringKey = "")
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>();
            var connectionString = !string.IsNullOrWhiteSpace(connectionStringKey) ? connectionStrings.FirstOrDefault(item => item.Name == connectionStringKey) : connectionStrings.FirstOrDefault();

            return connectionString?.ConnectionString;
        }
    }
}
