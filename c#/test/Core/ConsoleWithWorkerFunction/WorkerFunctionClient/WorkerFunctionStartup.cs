using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleWithWorkerFunction.WorkerFunctionClient
{
    public class WorkerFunctionStartup : IDisposable
    {
        private IHost _host;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _host?.Dispose();
                _host = null;
            }
        }

        public async Task ExecuteWorkerFunction(CancellationTokenSource cancellationToken)
        {
            _host = InitializeHost();
            await _host.StartAsync(cancellationToken.Token);
            await _host.StopAsync(cancellationToken.Token);
        }

        public IHost InitializeHost()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices(ConfigureServices)
                .Build();

            return _host;
        }

        protected virtual void ConfigureAppConfiguration(HostBuilderContext hostBuilderContext, IConfigurationBuilder builder)
        {
            builder.AddJsonFile("appsettings.json", true, true);
            builder.AddEnvironmentVariables();
        }

        protected virtual void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {}
    }
}
