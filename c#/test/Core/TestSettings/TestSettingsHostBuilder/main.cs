using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TestSettings;

namespace TestSettingsHostBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", true, true);
                    builder.AddEnvironmentVariables();
                    builder.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.AddSingleton<IConfigureOptions<AppSettings>>(new ConfigureNamedOptions<AppSettings>(nameof(AppSettings), appSettings => {}));
                });

            var host = builder.Build();

            AppSettings appSettings = host.Services.GetRequiredService<IOptions<AppSettings>>()?.Value;
            appSettings = host.Services.GetService<AppSettings>();
            appSettings = host.Services.GetRequiredService<AppSettings>();
        }
    }
}
