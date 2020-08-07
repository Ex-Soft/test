using System;
using WireMock.Server;
using WireMock.Settings;

using static System.Console;

namespace TestAdminApi
{
    class Program
    {
        static void Main(string[] args)
        {
            WireMockServer stub = null;

            try
            {
                var port = 5303;
                var baseUrl = "http://localhost:" + port;

                stub = WireMockServer.Start(new FluentMockServerSettings
                {
                    Urls = new[] {"http://+:" + port},
                    ReadStaticMappings = true
                });

                foreach (var mapping in stub.Mappings)
                {
                    WriteLine(mapping);
                }
            }
            catch (Exception eException)
            {
                WriteLine($"{eException.GetType().FullName}{Environment.NewLine}Message: {eException.Message}{Environment.NewLine}{(eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? $"InnerException.Message {eException.InnerException.Message}{Environment.NewLine}" : string.Empty)}StackTrace:{Environment.NewLine}{eException.StackTrace}");
            }
            finally
            {
                stub?.Stop();
                stub?.Dispose();
            }
        }
    }
}
