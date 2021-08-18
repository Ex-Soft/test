using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleWithWorkerFunction.WorkerFunctionClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using static System.Console;

namespace ConsoleWithWorkerFunction
{
    class Startup : WorkerFunctionStartup
    {
        static async Task Main(string[] args)
        {
            Startup host = new Startup();
            bool isShutdown = false;

            while (!isShutdown)
            {
                CancellationTokenSource cancellationToken = new CancellationTokenSource();

                try
                {
                    await host.ExecuteWorkerFunction(cancellationToken);
                }
                catch (Exception e)
                {
                    WriteLine(e);
                    isShutdown = true;
                }
            }

            host.Dispose();
        }

        protected override void ConfigureAppConfiguration(HostBuilderContext hostBuilderContext, IConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(hostBuilderContext, builder);

            builder.AddCommandLine(Environment.GetCommandLineArgs());
        }

        protected override void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            base.ConfigureServices(hostBuilderContext, services);

            _ = services.AddHostedService<CustomService>();
        }
    }
}
