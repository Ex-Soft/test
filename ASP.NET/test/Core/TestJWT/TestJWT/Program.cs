// https://metanit.com/sharp/aspnet5/23.7.php
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TestJWT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
