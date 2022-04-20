using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;

namespace ConsoleAppDIHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddHttpClient("HttpClient", configure =>
                        {
                            configure.BaseAddress = new Uri("http://localhost:5294");
                        })
                        .AddPolicyHandler(GetRetryPolicy());

                    services.AddTransient<TestPollyService>();
                });

            var host = builder.Build();

            using var serviceScope = host.Services.CreateScope();

            var services = serviceScope.ServiceProvider;
            try
            {
                var service = services.GetRequiredService<TestPollyService>();
                await service.Run();
                WriteLine("Success");
            }
            catch (Exception e)
            {
                WriteLine(e);
            }

            ReadLine();
        }

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
