using Microsoft.Extensions.Configuration;

using static System.Console;

namespace TestSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            WriteLine($"config[\"AppSettings:DbConnectionName\"] = \"{config["AppSettings:DbConnectionName"]}\"");
            WriteLine($"config[\"AppSettings:Victim\"] = \"{config["AppSettings:Victim"]}\"");

            WriteLine($"config[\"ConnectionStrings:MsSqlDbConnection:ConnectionString\"] = \"{config["ConnectionStrings:MsSqlDbConnection:ConnectionString"]}\"");
            WriteLine($"config[\"ConnectionStrings:MsSqlDbConnection:ProviderName\"] = \"{config["ConnectionStrings:MsSqlDbConnection:ProviderName"]}\"");

            WriteLine($"config[\"exclude:0\"] = \"{config["exclude:0"]}\"");
            WriteLine($"config[\"exclude:1\"] = \"{config["exclude:1"]}\"");
            WriteLine($"config[\"exclude:2\"] = \"{config["exclude:2"]}\"");
            WriteLine($"config[\"exclude:3\"] = \"{config["exclude:3"]}\"");
            WriteLine($"config[\"exclude:4\"] = \"{config["exclude:4"]}\"");
            WriteLine($"config[\"exclude:5\"] = \"{config["exclude:5"]}\"");

            WriteLine($"config[\"env1\"] = \"{config["env1"]}\"");
            WriteLine($"config[\"env2\"] = \"{config["env2"]}\"");

            WriteLine($"config[\"arg1\"] = \"{config["arg1"]}\"");
            WriteLine($"config[\"arg2\"] = \"{config["arg2"]}\"");
        }
    }
}
