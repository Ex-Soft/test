using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace ConsoleDI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Configure<TOptions>(
            this IServiceCollection services,
            Action<TOptions, IServiceProvider> configureOptions)
            where TOptions : class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (configureOptions == null)
                throw new ArgumentNullException(nameof(configureOptions));

            services.AddOptions();

            services.TryAddSingleton<IConfigureOptions<TOptions>>(provider => new ConfigureNamedOptions<TOptions, IServiceProvider>(Options.DefaultName, provider, configureOptions));

            return services;
        }

        // https://espressocoder.com/2018/10/08/injecting-a-factory-service-in-asp-net-core/
        public static IServiceCollection AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(x => () =>
            {
                return x.GetService<TService>();
            });

            return services;
        }
    }
}
