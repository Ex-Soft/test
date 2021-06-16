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
    }
}
