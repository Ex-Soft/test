using System.Configuration;
using System.Linq;

namespace TestMultiFileConfig
{
    class Program
    {
        const string
            ConnectionStringKey = "chicago";

        static void Main(string[] args)
        {
            string
                ConnectionString = string.Empty,
                Var1 = string.Empty,
                Var2 = string.Empty,
                Var3 = string.Empty;

            if (ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Any(cs => cs.Name == ConnectionStringKey))
                ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString;

            Var1 = ConfigurationManager.AppSettings["Var1"];
            Var2 = ConfigurationManager.AppSettings["Var2"];
            Var3 = ConfigurationManager.AppSettings["Var3"];
        }
    }
}
