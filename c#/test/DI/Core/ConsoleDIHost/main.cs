// https://www.thecodebuzz.com/dependency-injection-console-app-using-generic-hostbuilder/

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using static System.Console;

namespace ConsoleDIHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<MyApplication>();

                    services.AddTransient<IParam1, Param1>();
                    services.AddTransient<IParam2, Param2>();
                    services.AddTransient<IParam3, Param3>();

                    services.AddTransient<ICaller, Caller>();
                });

            var host = builder.Build();

            using var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            try
            {
                var myService = services.GetRequiredService<MyApplication>();
                await myService.Run();
                WriteLine("Success");
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
        }
    }
}
