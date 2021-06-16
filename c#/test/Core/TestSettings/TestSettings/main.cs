using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static System.Console;

namespace TestSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            services.AddOptions();
            services.Configure<AppSettings>(config.GetSection(nameof(AppSettings)));
            services.Configure<Excludes>(option => config.GetSection("Exclude").Bind(option.Exclude));
            services.Configure<TestType>(config.GetSection(nameof(TestType)));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IConfigurationSection[] arrayOfAppSettings = config.GetSection("AppSettings").GetChildren().ToArray();
            for (int i = 0; i < arrayOfAppSettings.Length; ++i)
            {
                WriteLine($"[{i}].Key=\"{arrayOfAppSettings[i].Key}\", [{i}].Path=\"{arrayOfAppSettings[i].Path}\", [{i}].Value=\"{arrayOfAppSettings[i].Value}\"");
            }

            AppSettings appSettings = serviceProvider.GetService<IOptions<AppSettings>>()?.Value;
            WriteLine($"DbConnectionName={(appSettings != null && appSettings.DbConnectionName != null ? $"\"{appSettings.DbConnectionName}\"" : "null")}, Victim={(appSettings is {Victim: { }} ? $"\"{appSettings.Victim}\"" : "null")}");

            //var excludes = config.GetSection("Exclude").GetChildren().ToArray();
            //var excludes = config.GetSection("Exclude").Get<List<string>>();
            var excludes = serviceProvider.GetService<IOptions<Excludes>>()?.Value;

            var testType = serviceProvider.GetService<IOptions<TestType>>()?.Value;

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
