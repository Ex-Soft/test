using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleWithGenericHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", true, true);
                    builder.AddEnvironmentVariables();
                    builder.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ConsoleHostedService>();
                    services.AddSingleton<IWeatherService, WeatherService>();
                    services.AddOptions<WeatherSettings>().Bind(hostContext.Configuration.GetSection("Weather"));
                })
                .RunConsoleAsync();
        }
    }
}
