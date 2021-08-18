using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TestConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TypeDescriptor.AddAttributes(typeof(Type), new TypeConverterAttribute(typeof(StringToTypeConverter)));

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
