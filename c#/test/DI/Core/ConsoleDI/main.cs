using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient<IParam1, Param1>();
            services.AddTransient<IParam2, Param2>();
            services.AddTransient<IParam3, Param3>();

            services.AddTransient<ICaller, Caller>();
            services.AddTransient<ICallerWithParams, CallerWithParams>();

            //services.Configure<Params>(@params =>
            //{
            //    @params.Param1 = new Param1();
            //    @params.Param2 = new Param2();
            //    @params.Param3 = new Param3();
            //});

            services.Configure<Params>((@params, provider) =>
            {
                @params.Param1 = provider.GetService<IParam1>();
                @params.Param2 = provider.GetService<IParam2>();
                @params.Param3 = provider.GetService<IParam3>();
            });

            var serviceProvider = services.BuildServiceProvider();

            var caller = serviceProvider.GetService<ICaller>();
            Debug.WriteLine(caller?.GetParams());

            var callerWithParams = serviceProvider.GetService<ICallerWithParams>();
            Debug.WriteLine(callerWithParams?.Params);
        }
    }
}
